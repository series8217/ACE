using ACE.Server.Managers;
using ACE.Network.Structure;

namespace ACE.Network.GameEvent.Events
{
    public class GameEventSendClientContractTrackerTable : GameEventMessage
    {
        public GameEventSendClientContractTrackerTable(Session session) : base(GameEventType.SendClientContractTrackerTable, GameMessageGroup.UIQueue, session)
        {
            Writer.Write(session.Player.ContractManager);
        }
    }
}
