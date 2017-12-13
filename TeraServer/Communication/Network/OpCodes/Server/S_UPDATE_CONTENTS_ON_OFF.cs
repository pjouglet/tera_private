using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_UPDATE_CONTENTS_ON_OFF : AServerPacket
    {
        private int content;
        public S_UPDATE_CONTENTS_ON_OFF(int content)
        {
            this.content = content;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, content);
            WriteByte(writer, 0);
        }
    }
}