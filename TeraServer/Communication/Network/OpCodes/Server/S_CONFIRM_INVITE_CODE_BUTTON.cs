using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_CONFIRM_INVITE_CODE_BUTTON : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 15);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteByte(writer, 0);
        }
    }
}