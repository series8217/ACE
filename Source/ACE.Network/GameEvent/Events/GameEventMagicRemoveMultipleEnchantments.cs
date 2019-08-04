using System.Collections.Generic;
using ACE.Network.Structure;

namespace ACE.Network.GameEvent.Events
{
    /// <summary>
    /// Removes multiple enchantments from your character.
    /// </summary>
    public class GameEventMagicRemoveMultipleEnchantments : GameEventMessage
    {
        public GameEventMagicRemoveMultipleEnchantments(Session session, List<LayeredSpell> spells)
            : base(GameEventType.MagicRemoveMultipleEnchantments, GameMessageGroup.UIQueue, session)
        {
            Writer.Write(spells);
        }
    }
}
