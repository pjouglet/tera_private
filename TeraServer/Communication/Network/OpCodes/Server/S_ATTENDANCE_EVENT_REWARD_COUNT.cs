using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_ATTENDANCE_EVENT_REWARD_COUNT : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 0);
        }
    }
}