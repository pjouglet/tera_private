using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_DAILY_QUEST_COMPLETE_COUNT : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 0);
            WriteInt16(writer, 10);
            WriteByte(writer, 0);
        }
    }
}