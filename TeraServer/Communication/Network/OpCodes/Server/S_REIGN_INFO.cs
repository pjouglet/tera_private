using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_REIGN_INFO : AServerPacket
    {
        private int info;

        public S_REIGN_INFO(int info)
        {
            this.info = info;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 12);
            WriteInt16(writer, 14);
            WriteInt32(writer, this.info);
            WriteInt16(writer, 0);
            WriteInt16(writer, 0);
        }
    }
}