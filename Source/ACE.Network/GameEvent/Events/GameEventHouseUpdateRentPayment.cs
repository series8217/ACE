using System;
using System.Collections.Generic;
using ACE.Network.Structure;

namespace ACE.Network.GameEvent.Events
{
    public class GameEventHouseUpdateRentPayment : GameEventMessage
    {
        public GameEventHouseUpdateRentPayment(Session session)
            : base(GameEventType.UpdateRentPayment, GameMessageGroup.UIQueue, session)
        {
            //Console.WriteLine("Sending 0x228 - House - UpdateRentPayment");

            var payments = new List<HousePayment>();

            Writer.Write(payments);
        }
    }
}
