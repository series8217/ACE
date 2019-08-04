using ACE.Common.Extensions;
using ACE.Network.GameEvent.Events;

namespace ACE.Network.GameAction.Actions
{
    public static class GameActionFellowshipCreate
    {
        [GameAction(GameActionType.FellowshipCreate)]
        public static void Handle(ClientMessage message, Session session)
        {
            var fellowshipName = message.Payload.ReadString16L();
            bool shareXp = message.Payload.ReadUInt32() > 0;

            session.Player.FellowshipCreate(fellowshipName, shareXp);
            session.Network.EnqueueSend(new GameEventFellowshipFullUpdate(session));
            session.Network.EnqueueSend(new GameEventFellowshipFellowUpdateDone(session));
        }
    }
}
