using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_LOAD_ACHIEVEMENT_LIST : AServerPacket
    {
        private Player _player;

        public S_LOAD_ACHIEVEMENT_LIST(Player player)
        {
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, (short)this._player.Achievements.completed.Count);
            short next = (short)writer.BaseStream.Position;
            WriteInt16(writer, 0);
            WriteInt16(writer, 6);
            short historyoffset = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            writeWorldId(writer, this._player);
            WriteInt32(writer, 0);
            WriteInt16(writer, (short)this._player.Achievements.completed.Count);
            WriteLong(writer, this._player.Achievements.getTotalPoints());

            for (int i = 0; i < this._player.Achievements.completed.Count; i++)
            {
                writetoPos(writer, next, (short)writer.BaseStream.Position);
                next = (short)writer.BaseStream.Position;
                WriteInt16(writer, 0);
                WriteInt32(writer, this._player.Achievements.completed[i].id);
                WriteInt16(writer, 4256);//?
                WriteInt16(writer, (short)this._player.Achievements.completed[i].category);
                WriteInt32(writer, 0);
            }

            for (int i = 0; i < 6; i++)
            {
                writetoPos(writer, historyoffset, (short)writer.BaseStream.Position);
                historyoffset = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);
                if (i == 0)
                {
                    WriteLong(writer, 0);
                    WriteLong(writer, 0);
                }
                else
                {
                    WriteInt32(writer, i);
                    WriteInt32(writer, 5);
                    WriteLong(writer, Utils.Funcs.GetCurrentMilliseconds());
                }
            }
            
        }
    }
}