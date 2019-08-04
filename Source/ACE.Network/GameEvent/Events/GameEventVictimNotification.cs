namespace ACE.Network.GameEvent.Events
{
    public class GameEventVictimNotification : GameEventMessage
    {
        public GameEventVictimNotification(Session session, string deathMessage)
            : base(GameEventType.VictimNotification, GameMessageGroup.UIQueue, session)
        {
            Writer.WriteString16L(deathMessage);
        }
    }
}