using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_DELETE_USER : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteByte(writer, 1);
        }
    }
}