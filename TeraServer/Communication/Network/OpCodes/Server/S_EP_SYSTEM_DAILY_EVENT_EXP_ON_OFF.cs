using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_EP_SYSTEM_DAILY_EVENT_EXP_ON_OFF : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 0);
        }
    }
}