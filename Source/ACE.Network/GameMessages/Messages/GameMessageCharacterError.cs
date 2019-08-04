using ACE.Network.Enum;

namespace ACE.Network.GameMessages.Messages
{
    public class GameMessageCharacterError : GameMessage
    {
        public GameMessageCharacterError(CharacterError error)
            : base(GameMessageOpcode.CharacterError, GameMessageGroup.UIQueue)
        {
            Writer.Write((uint)error);
        }
    }
}
