using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_INVEN : AServerPacket
    {
        private Player _player;
        public S_INVEN(Player player)
        {
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            //todo
            WriteInt16(writer, 0);//count
            short next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            
            writeWorldId(writer, this._player);
            WriteLong(writer, 2000);
            WriteByte(writer, 1);
            WriteByte(writer, 1);
            WriteByte(writer, 0);
            WriteInt32(writer, 40);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
        }
    }
}