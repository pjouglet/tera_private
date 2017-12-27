using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_VISITED_SECTION_LIST : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 0);
        }
    }
}