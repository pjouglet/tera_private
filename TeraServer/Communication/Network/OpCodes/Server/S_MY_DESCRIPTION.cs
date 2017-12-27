using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_MY_DESCRIPTION : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 6);
        }
    }
}