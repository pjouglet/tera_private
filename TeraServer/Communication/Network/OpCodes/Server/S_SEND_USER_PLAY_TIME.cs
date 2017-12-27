using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SEND_USER_PLAY_TIME : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 0);//time
            WriteLong(writer, 0);//creationtime
        }
    }
}