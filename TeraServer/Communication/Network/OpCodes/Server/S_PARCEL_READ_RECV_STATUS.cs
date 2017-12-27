using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_PARCEL_READ_RECV_STATUS : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 2);//total unread
            WriteInt32(writer, 3);//read unclaimed parcel
        }
    }
}