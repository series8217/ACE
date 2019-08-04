using ACE.Server.WorldObjects;

namespace ACE.Network.GameEvent.Events
{
    public class GameEventItemServerSaysContainId : GameEventMessage
    {
        public GameEventItemServerSaysContainId(Session session, WorldObject itemToBeContained, WorldObject container)
            : base(GameEventType.InventoryPutObjInContainer, GameMessageGroup.UIQueue, session)
        {
            Writer.WriteGuid(itemToBeContained.Guid);
            Writer.WriteGuid(container.Guid);
            Writer.Write(itemToBeContained.PlacementPosition ?? 0);
            Writer.Write((uint)itemToBeContained.ContainerType);
        }
    }
}
