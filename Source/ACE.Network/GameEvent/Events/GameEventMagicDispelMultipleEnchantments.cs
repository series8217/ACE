using System.Collections.Generic;
using ACE.Database.Models.Shard;
using ACE.Network.Structure;

namespace ACE.Network.GameEvent.Events
{
    /// <summary>
    /// Silently remove multiple enchantments from your character (no message in the chat window).
    /// </summary>
    public class GameEventMagicDispelMultipleEnchantments : GameEventMessage
    {
        public GameEventMagicDispelMultipleEnchantments(Session session, List<LayeredSpell> spells)
            : base(GameEventType.MagicDispelMultipleEnchantments, GameMessageGroup.UIQueue, session)
        {
            Writer.Write(spells);
        }

        public GameEventMagicDispelMultipleEnchantments(Session session, List<BiotaPropertiesEnchantmentRegistry> enchantments)
            : base(GameEventType.MagicDispelMultipleEnchantments, GameMessageGroup.UIQueue, session)
        {
            Writer.Write(enchantments);
        }
    }
}
