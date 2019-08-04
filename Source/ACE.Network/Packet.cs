using System.Collections.Generic;
using System.IO;

namespace ACE.Network
{
    public abstract class Packet
    {
        public PacketHeader Header { get; protected set; }
        public MemoryStream Data { get; internal set; }
        public List<PacketFragment> Fragments { get; } = new List<PacketFragment>();
    }
}
