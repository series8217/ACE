using System;

namespace ACE.Network.GameAction.Actions
{
    public static class GameActionBookAddPage
    {
        [GameAction(GameActionType.BookAddPage)]
        public static void Handle(ClientMessage message, Session session)
        {
            var bookGuid = message.Payload.ReadUInt32();

            //Console.WriteLine($"0xAC - BookAddPage({bookGuid:X8})");

            session.Player.HandleActionBookAddPage(bookGuid);
        }
    }
}
