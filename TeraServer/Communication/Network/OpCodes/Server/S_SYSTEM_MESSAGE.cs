using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SYSTEM_MESSAGE : AServerPacket
    {
        private string _msg;
        public S_SYSTEM_MESSAGE(string msg)
        {
            this._msg = msg;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 6);//message pos
            WriteString(writer, this._msg);
        }
    }
}