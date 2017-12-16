using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_LOADING_SCREEN_CONTROL_INFO : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 0);
        }
    }
}