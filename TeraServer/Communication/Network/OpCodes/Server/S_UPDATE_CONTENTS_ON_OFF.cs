using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_UPDATE_CONTENTS_ON_OFF : AServerPacket
    {
        private int content;
        private byte _off;
        public S_UPDATE_CONTENTS_ON_OFF(int content, byte off = 0)
        {
            this.content = content;
            this._off = off;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, content);
            WriteByte(writer, this._off);
        }
    }
}