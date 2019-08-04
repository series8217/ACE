namespace ACE.Network.Sequence
{
    public interface ISequence
    {
        byte[] NextBytes { get; }
        byte[] CurrentBytes { get; }
    }
}
