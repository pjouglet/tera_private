using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{    
    public class S_GET_USER_LIST : AServerPacket
    {
        private Connection _connection;
        public S_GET_USER_LIST(Connection connection)
        {
            this._connection = connection;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, (short)this._connection.Account.Players.Count);//count_pos
            
            short next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);//next_pos
            
            WriteBytes(writer, new byte[1]{1});//veteran
            WriteInt32(writer, 1);//time remaining
            WriteInt32(writer, 8);//max char
            WriteInt32(writer, 1);
            WriteBytes(writer, new byte[1]{0});
            WriteBytes(writer, new byte[1]{0});
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);

            for(int i =0; i < this._connection.Account.Players.Count; i++)
            {
                Player player = this._connection.Account.Players[i];
                if (i != this._connection.Account.Players.Count)
                {
                    writer.Seek(next, SeekOrigin.Begin);
                    WriteInt16(writer, (short) writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);
                }
                
                
                WriteInt16(writer, (short) writer.BaseStream.Position);
                next = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);
                
                WriteInt32(writer, 0);
                short namePos = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);

                short details1 = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);
                WriteInt16(writer, (short) player.details1.Length);
                
                short details2 = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);
                WriteInt16(writer, (short) player.details2.Length);
                
                
                
                WriteInt32(writer, player.playerId);
                WriteInt32(writer, player.gender);
                WriteInt32(writer, player.classId);
                WriteInt32(writer, player.level);
                WriteDouble(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, player.worldMapWorldId);
                WriteInt32(writer, player.worldMapGuardId);
                WriteInt32(writer, player.areaId);
                WriteDouble(writer, player.lastOnline);
                WriteBytes(writer, new byte[1]{0});//deletion
                WriteDouble(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, 0);//weapon
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
                WriteBytes(writer, player.details3);
                WriteBytes(writer, new byte[1]{0});
                WriteInt32(writer, 0);//GM
                WriteBytes(writer, new byte[1]{0});
                WriteDouble(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, 0);//unk
                WriteInt32(writer, 0);//unk
                WriteInt32(writer, 0);//unk
                WriteInt32(writer, 0);//unk
                WriteInt32(writer, 0);//unk
                WriteInt32(writer, 0);//unk
                WriteInt32(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, 0);//unk
                WriteInt32(writer, 0);//unk
                WriteInt32(writer, 0);//unk
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
                WriteInt32(writer, player.xp);
                WriteInt32(writer, player.restedXp);
                WriteBytes(writer, new byte[1]{1});
                WriteInt32(writer, 0);
                WriteBytes(writer, new byte[1]{0});
                WriteBytes(writer, new byte[1]{1});//show style
                WriteInt32(writer, 100);
                WriteInt32(writer, 0);//achievement points
                WriteInt32(writer, 0);//laurel
                WriteInt32(writer, player.lobbyPosition);
                WriteInt32(writer, 0);

                writer.Seek(namePos, SeekOrigin.Begin);
                WriteInt16(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);
                WriteString(writer, player.name);

                writer.Seek(details1, SeekOrigin.Begin);
                WriteInt16(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);
                WriteBytes(writer, player.details1);

                writer.Seek(details2, SeekOrigin.Begin);
                WriteInt16(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);
                WriteBytes(writer, player.details2);
            }
        }
    }
}