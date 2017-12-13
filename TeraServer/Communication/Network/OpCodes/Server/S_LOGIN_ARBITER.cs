using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_LOGIN_ARBITER : AServerPacket
    {
        private bool success;
        private int language;
        public S_LOGIN_ARBITER(int language, bool success = true)
        {
            this.success = success;
            this.language = language;
        }
        public override void Write(BinaryWriter writer)
        {
            if(this.success)
                WriteByte(writer, 1);
            else
                WriteByte(writer, 0);
            WriteByte(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, this.language);
            WriteByte(writer, 0);
            WriteInt16(writer, 0);
            WriteInt16(writer, 0);
            
        }
    }
}