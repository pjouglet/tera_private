using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_LOAD_CLIENT_ACCOUNT_SETTING : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 8);
            WriteInt16(writer, 0);
        }
    }
}