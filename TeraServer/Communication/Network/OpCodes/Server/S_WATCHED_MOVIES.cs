using System.Collections.Generic;
using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_WATCHED_MOVIES : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, (short) 0);//count
            short next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            
        }
    }
}