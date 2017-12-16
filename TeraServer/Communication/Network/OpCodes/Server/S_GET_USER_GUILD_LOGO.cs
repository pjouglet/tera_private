using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_GET_USER_GUILD_LOGO : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 0);
        }
    }
}