using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_MOVE_DISTANCE_DELTA : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteFloat(writer, 200);
        }
    }
}