using ACE.Network.Structure;

namespace ACE.Network.GameEvent.Events
{
    /// <summary>
    /// Apply an enchantment to your character.
    /// </summary>
    public class GameEventMagicUpdateEnchantment : GameEventMessage
    {
        public GameEventMagicUpdateEnchantment(Session session, Enchantment enchantment)
            : base(GameEventType.MagicUpdateEnchantment, GameMessageGroup.UIQueue, session)
        {
            Writer.Write(enchantment);
        }
    }
}
