using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_QA_SET_ADMIN_LEVEL : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 1);
        }
    }
}