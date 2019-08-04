using ACE.Entity.Enum;

namespace ACE.Network.GameEvent.Events
{
    public class GameEventCloseTrade : GameEventMessage
    {
        public GameEventCloseTrade(Session session, EndTradeReason endTradeReason)
            : base(GameEventType.CloseTrade, GameMessageGroup.UIQueue, session)
        {
            Writer.Write((uint)endTradeReason);
        }
    }
}
