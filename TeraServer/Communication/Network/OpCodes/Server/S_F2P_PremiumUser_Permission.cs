using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_F2P_PremiumUser_Permission : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 1);
            WriteInt16(writer, 20);
            WriteInt32(writer, 5);
            WriteFloat(writer, 1);
            WriteFloat(writer, 1);
            WriteInt32(writer, 20);
            WriteInt32(writer, 1);
        }
    }
}