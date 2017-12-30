using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_DIALOG : AServerPacket
    {
        private long npc_id;
        public S_DIALOG(long npc_id)
        {
            this.npc_id = npc_id;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 1);
            short next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            WriteInt32(writer, 0);
            WriteLong(writer, npc_id);
            WriteInt32(writer, 1);//type
            WriteInt32(writer, 802);//template id or quest id
            WriteInt32(writer, 181);//huntingzone id
            WriteInt32(writer, 0);
            WriteInt32(writer, 1);
            WriteInt32(writer, 0);//id ?
            WriteByte(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 1);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteByte(writer, 0);
            
            //array
            writetoPos(writer, next, (short) writer.BaseStream.Position);
            WriteInt16(writer, (short) writer.BaseStream.Position);
            next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            short namepos = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            WriteInt32(writer, 4);//type
            WriteInt32(writer, 0);//index
            WriteInt32(writer, 41);//style
            writetoPos(writer, namepos, (short) writer.BaseStream.Position);
            WriteString(writer, "@npc:4");

        }
    }
}