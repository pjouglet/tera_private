using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_CHAT : AServerPacket
    {
        private int channel;
        private string message;
        private Player _player;

        public S_CHAT(int channel, string message, Player player)
        {
            this.channel = channel;
            this.message = message;
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            short authorName = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            short messageOffset = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            
            WriteInt32(writer, this.channel);
            writeWorldId(writer, this._player);
            WriteByte(writer, 0);
            if(this._player.GM == 1)
                WriteByte(writer, 1);
            else
                WriteByte(writer, 0);
            WriteByte(writer, 0);
            
            writetoPos(writer, authorName, (short)writer.BaseStream.Position);
            WriteString(writer, this._player.name);
            writetoPos(writer, messageOffset, (short)writer.BaseStream.Position);
            WriteString(writer, this.message);
        }
    }
}