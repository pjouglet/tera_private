using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SELECT_USER : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteByte(writer, 1);
            WriteLong(writer, 0);
            WriteByte(writer, 1);
            WriteByte(writer, 1);
        }
    }
}