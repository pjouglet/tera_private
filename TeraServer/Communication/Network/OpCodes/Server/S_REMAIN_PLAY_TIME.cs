using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_REMAIN_PLAY_TIME : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 6);
            WriteInt32(writer, 0);
        }
    }
}