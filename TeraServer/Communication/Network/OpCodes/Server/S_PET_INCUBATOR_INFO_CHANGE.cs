using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_PET_INCUBATOR_INFO_CHANGE : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 0);//count
            WriteInt16(writer, 0);//offset
            WriteInt32(writer, 1);
            WriteInt32(writer, 0);
            WriteInt32(writer, 60);
            WriteInt16(writer, 0);
        }
    }
}