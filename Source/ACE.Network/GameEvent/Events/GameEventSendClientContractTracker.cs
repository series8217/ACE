using ACE.Database.Models.Shard;
using ACE.Network.Structure;
using System;

namespace ACE.Network.GameEvent.Events
{
    public class GameEventSendClientContractTracker : GameEventMessage
    {
        public GameEventSendClientContractTracker(Session session, CharacterPropertiesContractRegistry contract) : base(GameEventType.SendClientContractTracker, GameMessageGroup.UIQueue, session)
        {
            var contractTracker = new ContractTracker(session.Player, contract);

            Writer.Write(contractTracker);
            Writer.Write(Convert.ToUInt32(contractTracker.DeleteContract));
            Writer.Write(Convert.ToUInt32(contractTracker.SetAsDisplayContract));
        }
    }
}
