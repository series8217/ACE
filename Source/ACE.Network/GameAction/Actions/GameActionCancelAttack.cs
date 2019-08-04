using ACE.Entity;

namespace ACE.Network.GameAction.Actions
{
    public static class GameActionCancelAttack
    {
        [GameAction(GameActionType.CancelAttack)]
        public static void Handle(ClientMessage message, Session session)
        {
            session.Player.HandleActionCancelAttack();
        }
    }
}
