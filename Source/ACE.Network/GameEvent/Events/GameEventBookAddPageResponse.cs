using System;

namespace ACE.Network.GameEvent.Events
{
    public class GameEventBookAddPageResponse : GameEventMessage
    {
        public GameEventBookAddPageResponse(Session session, uint bookGuid, uint page, bool success)
            : base(GameEventType.BookAddPageResponse, GameMessageGroup.UIQueue, session)
        {
            Writer.Write(bookGuid);
            Writer.Write(page);     // 0-based
            Writer.Write(Convert.ToUInt32(success));
        }
    }
}
