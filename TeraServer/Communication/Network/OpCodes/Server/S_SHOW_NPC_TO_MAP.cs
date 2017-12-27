using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SHOW_NPC_TO_MAP : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 0);
        }
    }
}