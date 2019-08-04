namespace ACE.Network.GameEvent.Events
{
    public class GameEventEvasionAttackerNotification : GameEventMessage
    {
        public GameEventEvasionAttackerNotification(Session session, string defenderName)
            : base(GameEventType.EvasionAttackerNotification, GameMessageGroup.UIQueue, session)
        {
            Writer.WriteString16L(defenderName);
        }
    }
}
