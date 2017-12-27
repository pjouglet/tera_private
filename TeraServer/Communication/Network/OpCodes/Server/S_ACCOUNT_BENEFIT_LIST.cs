using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_ACCOUNT_BENEFIT_LIST : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteByte(writer, 0);
            WriteInt32(writer, 0);
        }
    }
}