using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Serve
{
    public class S_LOGIN : AServerPacket
    {
        private Player _player;
        public S_LOGIN(Player player)
        {
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            short namePos = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);

            short details1 = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            WriteInt16(writer, (short) _player.details1.Length);
                
            short details2 = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            WriteInt16(writer, (short) _player.details2.Length);
            
            WriteInt32(writer, this._player.model);
            WriteSpawnId(writer, this._player, true);
            WriteInt32(writer, 0);
            WriteByte(writer, 1);//alive
            WriteInt32(writer, 0);
            WriteInt32(writer, 52);
            WriteInt32(writer, 110);
            WriteBytes(writer, _player.details3);
            WriteByte(writer, 1);
            WriteByte(writer, 0);
            WriteInt16(writer, (short)_player.level);
            WriteInt16(writer, 100);//energy
            WriteInt16(writer, 0);
            WriteInt16(writer, 100);//plant
            WriteInt16(writer, 100);//mining
            WriteInt16(writer, 1);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);//playerKills
            WriteLong(writer, _player.restedXp);
            WriteLong(writer, _player.xp);
            WriteLong(writer, 0);//next level xp
            WriteInt32(writer, 0);            
            WriteInt32(writer, 0);            
            WriteInt32(writer, 0);            
            WriteInt32(writer, 0); 
            WriteInt32(writer, 0);//rested current
            WriteInt32(writer, 419);//rested max
            WriteFloat(writer, 1);
            WriteFloat(writer, 1);
            WriteInt32(writer, 0);//weapon
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);    
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteLong(writer, 0);//ingame time
            WriteByte(writer, 1);
            WriteLong(writer, 0);//ban chat until
            WriteInt32(writer, this._player.title);//title id
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
            WriteInt32(writer, 0);//infamy
            WriteByte(writer, 1);//show costume
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteByte(writer, 1);//show costume
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 100);
            WriteFloat(writer, 1);//scale
            WriteInt32(writer, 0);
            //WriteByte(writer, 1);
            writetoPos(writer, namePos, (short)writer.BaseStream.Position);
            WriteString(writer, _player.name);

            writetoPos(writer, details1, (short)writer.BaseStream.Position);
            WriteBytes(writer, _player.details1);
                
            writetoPos(writer, details2, (short)writer.BaseStream.Position);
            WriteBytes(writer, _player.details2);
            
        }
    }
}