using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_FATIGABILITY_POINT : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 1);
            WriteInt32(writer, 200);
        }
    }
}