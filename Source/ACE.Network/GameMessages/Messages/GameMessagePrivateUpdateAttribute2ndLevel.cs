using ACE.Entity.Enum;
using ACE.Server.WorldObjects;

namespace ACE.Network.GameMessages.Messages
{
    public class GameMessagePrivateUpdateAttribute2ndLevel : GameMessage
    {
        public GameMessagePrivateUpdateAttribute2ndLevel(WorldObject worldObject, Vital vital, uint value)
            : base(GameMessageOpcode.PrivateUpdateAttribute2ndLevel, GameMessageGroup.UIQueue)
        {
            Writer.Write(worldObject.Sequences.GetNextSequence(Sequence.SequenceType.UpdateAttribute2ndLevel, vital));
            Writer.Write((uint)vital);
            Writer.Write(value);
        }
    }
}