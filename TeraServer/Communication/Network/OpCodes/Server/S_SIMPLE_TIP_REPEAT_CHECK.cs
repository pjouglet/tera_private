using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SIMPLE_TIP_REPEAT_CHECK : AServerPacket
    {
        private int tip;

        public S_SIMPLE_TIP_REPEAT_CHECK(int tip)
        {
            this.tip = tip;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, this.tip);
            WriteByte(writer, 1);
        }
    }
}