namespace ACE.Network.GameMessages.Messages
{
    public class GameMessageCharacterDelete : GameMessage
    {
        public GameMessageCharacterDelete()
            : base(GameMessageOpcode.CharacterDelete, GameMessageGroup.UIQueue)
        {
        }
    }
}
