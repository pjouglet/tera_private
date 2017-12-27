using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_BROCAST_GUILD_FLAG : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 0);
        }
    }
}