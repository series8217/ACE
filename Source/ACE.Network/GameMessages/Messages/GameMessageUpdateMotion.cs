using ACE.Server.Entity;
using ACE.Network.Sequence;
using ACE.Server.WorldObjects;
using ACE.Network.Structure;

namespace ACE.Network.GameMessages.Messages
{
    public class GameMessageUpdateMotion : GameMessage
    {
        public GameMessageUpdateMotion(WorldObject wo, MovementData movementData)
            : base(GameMessageOpcode.Motion, GameMessageGroup.SmartboxQueue)
        {
            Send(wo, movementData);
        }

        public GameMessageUpdateMotion(WorldObject wo, Motion motion)
            : base(GameMessageOpcode.Motion, GameMessageGroup.SmartboxQueue)
        {
            Send(wo, new MovementData(wo, motion));
        }

        public void Send(WorldObject wo, MovementData movementData)
        {
            Writer.WriteGuid(wo.Guid);
            Writer.Write(wo.Sequences.GetCurrentSequence(SequenceType.ObjectInstance));
            Writer.Write(movementData);
        }
    }
}
