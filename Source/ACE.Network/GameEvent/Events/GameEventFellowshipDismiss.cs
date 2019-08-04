using ACE.Server.WorldObjects;

namespace ACE.Network.GameEvent.Events
{
    public class GameEventFellowshipDismiss : GameEventMessage
    {
        public GameEventFellowshipDismiss(Session session, Player dismissedPlayer)
            : base(GameEventType.FellowshipDismiss, GameMessageGroup.UIQueue, session)
        {
            // can be both S2C and C2S?
            Writer.Write(dismissedPlayer.Guid.Full);
        }
    }
}
