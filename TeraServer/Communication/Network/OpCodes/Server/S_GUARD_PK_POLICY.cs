using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class S_GUARD_PK_POLICY : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteByte(writer, 1);
        }
    }
}