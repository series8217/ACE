using System;
using System.Diagnostics;

using ACE.Common;
using ACE.Database.Models.Shard;
using ACE.Database.Models.World;
using ACE.DatLoader.Entity;
using ACE.Entity;
using ACE.Entity.Enum;
using ACE.Entity.Enum.Properties;
using ACE.Server.Entity;
using ACE.Server.Managers;
using ACE.Server.Network;
using ACE.Server.Network.Structure;
using ACE.Server.Network.GameEvent.Events;
using ACE.Server.Network.GameMessages.Messages;

namespace ACE.Server.WorldObjects
{
    public class Gem : Stackable
    {
        /// <summary>
        /// A new biota be created taking all of its values from weenie.
        /// </summary>
        public Gem(Weenie weenie, ObjectGuid guid) : base(weenie, guid)
        {
            SetEphemeralValues();
        }

        /// <summary>
        /// Restore a WorldObject from the database.
        /// </summary>
        public Gem(Biota biota) : base(biota)
        {
            SetEphemeralValues();
        }

        private void SetEphemeralValues()
        {
        }

        /// <summary>
        /// This is raised by Player.HandleActionUseItem.<para />
        /// The item should be in the players possession.
        /// 
        /// The OnUse method for this class is to use a contract to add a tracked quest to our quest panel.
        /// This gives the player access to information about the quest such as starting and ending NPC locations,
        /// and shows our progress for kill tasks as well as any timing information such as when we can repeat the
        /// quest or how much longer we have to complete it in the case of at timed quest.   Og II
        /// </summary>
        public override void ActOnUse(WorldObject activator)
        {
            if (!(activator is Player player))
                return;

            if (player.IsBusy || player.Teleporting)
            {
                player.Session.Network.EnqueueSend(new GameEventWeenieError(player.Session, WeenieError.YoureTooBusy));
                return;
            }

            if (UseCreateContractId != null)
            {
                ActOnUseContract(player);
                return;
            }

            if (!string.IsNullOrWhiteSpace(UseSendsSignal))
            {
                player.CurrentLandblock?.EmitSignal(player, UseSendsSignal);
                return;
            }

            // handle rare gems
            if (RareUsesTimer)
            {
                var currentTime = Time.GetUnixTime();

                var timeElapsed = currentTime - player.LastRareUsedTimestamp;

                if (timeElapsed < RareTimer)
                {
                    // TODO: get retail message
                    var remainTime = (int)Math.Ceiling(RareTimer - timeElapsed);
                    player.Session.Network.EnqueueSend(new GameMessageSystemChat($"You may use another timed rare in {remainTime}s", ChatMessageType.Broadcast));
                    return;
                }

                player.LastRareUsedTimestamp = currentTime;

                // local broadcast usage
                player.EnqueueBroadcast(new GameMessageSystemChat($"{player.Name} used the rare item {Name}", ChatMessageType.Broadcast));
            }

            if (SpellDID.HasValue)
            {
                var spell = new Server.Entity.Spell((uint)SpellDID);

                TryCastSpell(spell, player, this);
            }

            if ((GetProperty(PropertyBool.UnlimitedUse) ?? false) == false)
                player.TryConsumeFromInventoryWithNetworking(this, 1);
        }

        public void ActOnUseContract(Player player)
        {
            ContractTracker contractTracker = new ContractTracker((uint)UseCreateContractId, player.Guid.Full)
            {
                Stage = 0,
                TimeWhenDone = 0,
                TimeWhenRepeats = 0,
                DeleteContract = 0,
                SetAsDisplayContract = 1
            };

            if (CooldownId != null && player.LastUseTracker.TryGetValue(CooldownId.Value, out var lastUse))
            {
                var timeRemaining = lastUse.AddSeconds(CooldownDuration ?? 0.00).Subtract(DateTime.Now);
                if (timeRemaining.Seconds > 0)
                {
                    ChatPacket.SendServerMessage(player.Session, "You cannot use another contract for " + timeRemaining.Seconds + " seconds", ChatMessageType.Broadcast);
                    return;
                }
            }

            // We need to see if we are tracking this quest already.   Also, I cannot be used on world, so I must have a container id
            if (!player.TrackedContracts.ContainsKey((uint)UseCreateContractId) && ContainerId != null)
            {
                player.TrackedContracts.Add((uint)UseCreateContractId, contractTracker);

                // This will track our use for each contract using the shared cooldown server side.
                if (CooldownId != null)
                {
                    // add or update.
                    if (!player.LastUseTracker.ContainsKey(CooldownId.Value))
                        player.LastUseTracker.Add(CooldownId.Value, DateTime.Now);
                    else
                        player.LastUseTracker[CooldownId.Value] = DateTime.Now;
                }

                player.Session.Network.EnqueueSend(new GameEventSendClientContractTracker(player.Session, contractTracker));
                ChatPacket.SendServerMessage(player.Session, "You just added " + contractTracker.ContractDetails.ContractName, ChatMessageType.Broadcast);

                // TODO: Add sending the 02C2 message UpdateEnchantment.   They added a second use to this existing system
                // so they could show the delay on the client side - it is not really an enchantment but the they overloaded the use. Og II
                // Thanks Slushnas for letting me know about this as well as an awesome pcap that shows it all in action.

                // TODO: there is a lot of work to do here.   I am stubbing this in for now to send the right message.   Lots of magic numbers at the moment.
                Debug.Assert(CooldownId != null, "CooldownId != null");
                Debug.Assert(CooldownDuration != null, "CooldownDuration != null");
                //const ushort layer = 0x10000; // FIXME: we need to track how many layers of the exact same spell we have in effect.
                const ushort layer = 1;
                //const uint spellCategory = 0x8000; // FIXME: Not sure where we get this from
                var spellBase = new SpellBase(0, CooldownDuration.Value, 0, -666);
                // cooldown not being used in network packet?
                var gem = new Enchantment(player, spellBase, layer, /*CooldownId.Value,*/ EnchantmentMask.Cooldown);
                player.Session.Network.EnqueueSend(new GameEventMagicUpdateEnchantment(player.Session, gem));

                // Ok this was not known to us, so we used the contract - now remove it from inventory.
                // HandleActionRemoveItemFromInventory is has it's own action chain.
                player.TryConsumeFromInventoryWithNetworking(this, 1);
            }
            else
                ChatPacket.SendServerMessage(player.Session, "You already have this quest tracked: " + contractTracker.ContractDetails.ContractName, ChatMessageType.Broadcast);
        }

        public int? RareId
        {
            get => GetProperty(PropertyInt.RareId);
            set { if (!value.HasValue) RemoveProperty(PropertyInt.RareId); else SetProperty(PropertyInt.RareId, value.Value); }
        }

        public bool RareUsesTimer
        {
            get => GetProperty(PropertyBool.RareUsesTimer) ?? false;
            set { if (!value) RemoveProperty(PropertyBool.RareUsesTimer); else SetProperty(PropertyBool.RareUsesTimer, value); }
        }

        public override void HandleActionUseOnTarget(Player player, WorldObject target)
        {
            // should tailoring kit / aetheria be subtyped?
            if (Tailoring.IsTailoringKit(WeenieClassId))
            {
                Tailoring.UseObjectOnTarget(player, this, target);
                return;
            }

            // fallback on recipe manager?
            base.HandleActionUseOnTarget(player, target);
        }

        /// <summary>
        /// For Rares that use cooldown timers (RareUsesTimer),
        /// any other rares with RareUsesTimer may not be used for 3 minutes
        /// Note that if the player logs out, this cooldown timer continues to tick/expire (unlike enchantments)
        /// </summary>
        public static int RareTimer = 180;

        public string UseSendsSignal
        {
            get => GetProperty(PropertyString.UseSendsSignal);
            set { if (value == null) RemoveProperty(PropertyString.UseSendsSignal); else SetProperty(PropertyString.UseSendsSignal, value); }
        }
    }
}
