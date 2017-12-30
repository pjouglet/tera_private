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
            Class_Template template = Class_Template.ClassTemplates[Convert.ToInt32(_player.classId)];
            WriteInt16(writer, (short) template.SkillList.Count);
            short next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            
            for (int i = 0; i < template.SkillList.Count; i++)
            {
                writetoPos(writer, next, (short) writer.BaseStream.Position);
                WriteInt16(writer, (short) writer.BaseStream.Position);
                next = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);
                WriteInt32(writer, template.SkillList[i].id);
                if(template.SkillList[i].type == 1)
                    WriteByte(writer, 1);
                else if(template.SkillList[i].type == 0)
                    WriteByte(writer, 0);
            }
        }
    }
}