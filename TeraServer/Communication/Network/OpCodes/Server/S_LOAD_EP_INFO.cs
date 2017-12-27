using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_LOAD_EP_INFO : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteLong(writer, 0);
            WriteLong(writer, 0);
            WriteLong(writer, 0);
            WriteLong(writer, 0);
            WriteLong(writer, 0);
        }
    }
}