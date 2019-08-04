using ACE.Common.Extensions;

namespace ACE.Network.GameAction.Actions
{
    public static class GameActionSetAllegianceApprovedVassal
    {
        [GameAction(GameActionType.SetAllegianceApprovedVassal)]
        public static void Handle(ClientMessage message, Session session)
        {
            var playerName = message.Payload.ReadString16L();       // the approved vassal

            session.Player.HandleActionSetAllegianceApprovedVassal(playerName);
        }
    }
}