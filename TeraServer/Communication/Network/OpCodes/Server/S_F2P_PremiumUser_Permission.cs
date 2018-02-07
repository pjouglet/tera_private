using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_F2P_PremiumUser_Permission : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 1);
            WriteInt32(writer, 20);
            WriteInt32(writer, 0);
            WriteInt32(writer, 16256);
            WriteInt16(writer, 16256);
            WriteInt32(writer, 20);
            WriteInt32(writer, 1);
        }
    }
}