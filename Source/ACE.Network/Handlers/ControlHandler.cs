using ACE.Network.Enum;
using ACE.Network.GameMessages;

namespace ACE.Network.Handlers
{
    public static class ControlHandler
    {
        [GameMessage(GameMessageOpcode.ForceObjectDescSend, SessionState.WorldConnected)]
        public static void ControlResponse(ClientMessage message, Session session)
        {
            var itemGuid = message.Payload.ReadUInt32();
            session.Player.HandleActionForceObjDescSend(itemGuid);
        }
    }
}
