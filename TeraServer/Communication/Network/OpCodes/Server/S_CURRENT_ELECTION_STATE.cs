using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_CURRENT_ELECTION_STATE : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteLong(writer, 0);
            WriteLong(writer, 0);
            WriteInt32(writer, 0);
            WriteInt16(writer, 0);
        }
    }
}