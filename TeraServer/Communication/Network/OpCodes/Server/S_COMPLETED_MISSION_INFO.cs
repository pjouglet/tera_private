using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_COMPLETED_MISSION_INFO : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 0);
        }
    }
}