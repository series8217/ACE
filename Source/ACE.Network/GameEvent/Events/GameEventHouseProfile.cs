using System;
using ACE.Entity;
using ACE.Network.Structure;

namespace ACE.Network.GameEvent.Events
{
    /// <summary>
    /// Buy a house, or pay maintenance
    /// </summary>
    public class GameEventHouseProfile : GameEventMessage
    {
        public GameEventHouseProfile(Session session, ObjectGuid crystal, HouseProfile profile)
            : base(GameEventType.HouseProfile, GameMessageGroup.UIQueue, session)
        {
            //Console.WriteLine("Sending 0x21D - GameEventHouseProfile");

            Writer.Write(crystal.Full);
            Writer.Write(profile);
        }
    }
}
