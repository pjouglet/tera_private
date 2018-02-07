using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_LOAD_EP_INFO : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 1);
            short unk = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            WriteInt32(writer, 82);
            WriteInt32(writer, 213034);
            WriteInt32(writer, 0);
            WriteInt32(writer, 92);
            WriteInt32(writer, 1);
            WriteInt32(writer, 0);
            WriteInt32(writer, 17752);
            WriteInt32(writer, 60);
            WriteInt32(writer, 60);
            
            //array
            writetoPos(writer, unk, (short) writer.BaseStream.Position);
            WriteInt16(writer, (short) writer.BaseStream.Position);
            WriteInt16(writer, 0);
            WriteInt32(writer, 111000);
            WriteInt32(writer, 1);
            
        }
    }
}