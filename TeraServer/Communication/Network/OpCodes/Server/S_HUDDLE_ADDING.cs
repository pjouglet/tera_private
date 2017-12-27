using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_HUDDLE_ADDING : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 0);
        }
    }
}