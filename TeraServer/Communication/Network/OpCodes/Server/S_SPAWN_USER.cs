using System.IO;
using TeraServer.Data.Structures;
using TeraServer.Data.Structures.Enums;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SPAWN_USER : AServerPacket
    {
        private Player _player;
        public S_SPAWN_USER(Player player)
        {
            this._player = player;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 0);
            WriteInt16(writer, 1);
            
            short package = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            short namePos = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            short guildNamePos = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            short guildTitle = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            short details1 = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            WriteInt16(writer, 32);
            short guildEmblem = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            short details2 = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            WriteInt16(writer, 64);
            
            WriteSpawnId(writer, this._player, false);
            WriteFloat(writer, _player.posX);
            WriteFloat(writer, _player.posY);
            WriteFloat(writer, _player.posZ);
            WriteInt16(writer, (short) _player.heading);
            if(_player.GM == 1)
                WriteInt32(writer, (int)Player_Relation.GM);
            else
                WriteInt32(writer, 0);
            WriteInt32(writer, this._player.model);
            WriteInt16(writer, 0);
            WriteInt16(writer, 52);
            WriteInt16(writer, 190);
            WriteInt16(writer, 0);
            WriteInt16(writer, 0);//status
            WriteByte(writer, 1);
            WriteByte(writer, 1);
            WriteBytes(writer, this._player.details3);
            WriteInt32(writer, 0);//weapon
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);//spawn fx
            WriteInt32(writer, 0);//mount
            WriteInt32(writer, 0);//pose
            WriteInt32(writer, this._player.title);
            WriteLong(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);//exarch
            if(this._player.GM == 1)
                WriteByte(writer, 1);
            else
                WriteByte(writer, 0);
            WriteByte(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);//weapon enchant
            WriteByte(writer, 0);//newbie
            WriteByte(writer,0);//pk enabled
            WriteInt32(writer, this._player.level);
            WriteLong(writer, 0);
            WriteByte(writer, 1);
            WriteInt32(writer, 0);//style head
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);//party server
            WriteInt32(writer, 0);//party id
            WriteByte(writer, 0);
            WriteByte(writer, 1);//show style
            WriteInt32(writer, 24);
            WriteInt32(writer, 0);
            WriteInt32(writer, 100);
            WriteFloat(writer, 1);//scale
            
            writetoPos(writer, namePos, (short)writer.BaseStream.Length);
            WriteString(writer, this._player.name);
            
            writetoPos(writer, guildNamePos, (short)writer.BaseStream.Length);
            WriteInt16(writer, 0);
            
            writetoPos(writer, guildTitle, (short)writer.BaseStream.Length);
            WriteInt16(writer, 0);
            
            writetoPos(writer, details1, (short)writer.BaseStream.Length);
            WriteBytes(writer, this._player.details1);
            
            writetoPos(writer, guildEmblem, (short)writer.BaseStream.Length);
            WriteInt16(writer, 0);
            
            writetoPos(writer, details2, (short)writer.BaseStream.Length);
            WriteBytes(writer, this._player.details2);
            
            writetoPos(writer, package, (short)writer.BaseStream.Length);
            WriteInt16(writer, (short) writer.BaseStream.Position);
            WriteInt16(writer, 0);
            WriteInt32(writer, 333);

            
        }
    }
}