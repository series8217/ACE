using ACE.Entity;
using ACE.Entity.Enum;

namespace ACE.Network.GameEvent.Events
{
    public class GameEventClearTradeAcceptance : GameEventMessage
    {
        public GameEventClearTradeAcceptance(Session session)
            : base(GameEventType.ClearTradeAcceptance, GameMessageGroup.UIQueue, session)
        {
        }
    }
}
