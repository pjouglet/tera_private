using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_REQUEST_INVITE_GUILD_TAG : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 0);
        }
    }
}