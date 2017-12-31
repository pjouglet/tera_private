using System;
using System.IO;
using TeraServer.Data.Structures;
using TeraServer.Data.Structures.Templates;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SKILL_LIST : AServerPacket
    {
        private Player _player;

        public S_SKILL_LIST(Player player)
        {
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            
            WriteInt16(writer, (short) _player.learnedSkills.Count);
            short next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            
            for (int i = 0; i < _player.learnedSkills.Count; i++)
            {
                writetoPos(writer, next, (short) writer.BaseStream.Position);
                WriteInt16(writer, (short) writer.BaseStream.Position);
                next = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);
                WriteInt32(writer, _player.learnedSkills[i].id);
                if(_player.learnedSkills[i].type == 1)
                    WriteByte(writer, 1);
                else if(_player.learnedSkills[i].type == 0)
                    WriteByte(writer, 0);
            }
        }
    }
}