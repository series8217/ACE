using ACE.Server.Managers;

namespace ACE.Network.GameAction.Actions
{
    public static class GameActionCloseTradeNegotiations
    {
        [GameAction(GameActionType.CloseTradeNegotiations)]
        public static void Handle(ClientMessage message, Session session)
        {
            var target = PlayerManager.GetOnlinePlayer(session.Player.TradePartner);

            if (target != null)
            {
                session.Player.HandleActionCloseTradeNegotiations();

                //Close the trade window for the trade partner
                target.HandleActionCloseTradeNegotiations();
            }
        }
    }
}
