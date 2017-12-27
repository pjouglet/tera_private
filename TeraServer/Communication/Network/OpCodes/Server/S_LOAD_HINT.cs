using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_LOAD_HINT : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 0);
        }
    }
}