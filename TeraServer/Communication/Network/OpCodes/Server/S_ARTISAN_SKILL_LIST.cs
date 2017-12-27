using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_ARTISAN_SKILL_LIST : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 0);
            WriteInt16(writer, 0);
            WriteByte(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt16(writer, 0);
            WriteInt16(writer, 17480);
            WriteInt32(writer, 14);
        }
    }
}