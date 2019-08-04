using System;
using ACE.Network.Structure;

namespace ACE.Network.GameEvent.Events
{
    /// <summary>
    /// Update house access records, aka guest list
    /// </summary>
    public class GameEventUpdateHAR : GameEventMessage
    {
        public GameEventUpdateHAR(Session session)
            : base(GameEventType.UpdateHAR, GameMessageGroup.UIQueue, session)
        {
            //Console.WriteLine("Sending 0x257 - Update House Access Records (HAR)");

            var har = new HouseAccess();

            Writer.Write(har);
        }
    }
}
