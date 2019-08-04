using ACE.Network.Enum;
using ACE.Network.GameMessages;
using ACE.Network.Managers;

namespace ACE.Network.GameAction
{
    public static class GameActionPacket
    {
        [GameMessage(GameMessageOpcode.GameAction, SessionState.WorldConnected)]
        public static void HandleGameAction(ClientMessage message, Session session)
        {
            // TODO: verify sequence
            uint sequence = message.Payload.ReadUInt32();
            uint opcode   = message.Payload.ReadUInt32();

            InboundMessageManager.HandleGameAction((GameActionType)opcode, message, session);
        }
    }
}
