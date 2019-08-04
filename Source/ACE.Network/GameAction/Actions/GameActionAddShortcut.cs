using ACE.Network.Structure;

namespace ACE.Network.GameAction.Actions
{
    public static class GameActionAddShortcut
    {
        [GameAction(GameActionType.AddShortCut)]
        public static void Handle(ClientMessage message, Session session)
        {
            var shortcut = message.Payload.ReadShortcut();

            session.Player.HandleActionAddShortcut(shortcut);
        }
    }
}
