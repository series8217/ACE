using ACE.Entity.Enum;
using ACE.Network.GameEvent.Events;

namespace ACE.Network.GameAction.Actions
{
    public static class GameActionChannelList
    {
        [GameAction(GameActionType.ListChannels)]
        public static void Handle(ClientMessage message, Session session)
        {
            var chatChannelID = (Channel)message.Payload.ReadUInt32();

            if (session.AccessLevel == AccessLevel.Player && !session.Player.IsAdvocate)
                return;

            if (session.Player.ChannelsAllowed.HasValue && session.Player.ChannelsAllowed.Value.HasFlag(chatChannelID))
                session.Network.EnqueueSend(new GameEventChannelList(session, chatChannelID));
        }
    }
}
