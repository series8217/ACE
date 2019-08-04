﻿using ACE.Entity.Enum;
using ACE.Network.Enum;
using ACE.Network.GameMessages;

namespace ACE.Network.Handlers
{
    public static class FriendsOldHandler
    {
        [GameMessage(GameMessageOpcode.FriendsOld, SessionState.WorldConnected)]
        public static void FriendsOld(ClientMessage message, Session session)
        {
            ChatPacket.SendServerMessage(session, "That command is not used in the emulator.", ChatMessageType.Broadcast);
        }
    }
}