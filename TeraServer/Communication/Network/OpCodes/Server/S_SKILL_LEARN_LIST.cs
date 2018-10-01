using System;
using System.IO;
using TeraServer.Data.Structures;
using TeraServer.Data.Structures.Templates;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SKILL_LEARN_LIST : AServerPacket
    {
        private Player _player;

        public S_SKILL_LEARN_LIST(Player player)
        {
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            Class_Template template = Class_Template.ClassTemplates[Convert.ToInt32(_player.classId)];
            WriteInt16(writer, (short) template.SkillLearnList.Count);
            short next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);

            for (int i = 0; i < template.SkillLearnList.Count; i++)
            {
                short count = (short)(template.SkillLearnList[i].preActive.Count + template.SkillLearnList[i].prePassive.Count + template.SkillLearnList[i].preSkill.Count);
                
                writetoPos(writer, next, (short) writer.BaseStream.Position);
                WriteInt16(writer, (short) writer.BaseStream.Position);
                next = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);
                WriteInt16(writer, count);//required count
                short countPos = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);
                WriteInt32(writer, 0);
                WriteInt32(writer, template.SkillLearnList[i].id);
                if(template.SkillLearnList[i].type == 1)
                    WriteByte(writer, 1);
                else if(template.SkillLearnList[i].type == 0)
                    WriteByte(writer, 0);
                WriteInt32(writer, template.SkillLearnList[i].cost);
                WriteInt32(writer, template.SkillLearnList[i].level);
                if(this._player.learnedSkills.Contains(template.SkillLearnList[i]))
                    WriteByte(writer, 1);
                else
                    WriteByte(writer, 0);
                
                for (int j = 0; j < template.SkillLearnList[i].preActive.Count; j++)
                {
                    Skill_Template pre = Skill_Template.getTemplateById(template.SkillLearnList[i].preActive[j]);
                    if(pre == null)
                        Console.WriteLine(1);
                    writetoPos(writer, countPos, (short) writer.BaseStream.Position);
                    WriteInt16(writer, (short) writer.BaseStream.Position);
                    countPos = (short) writer.BaseStream.Position;
                    WriteInt16(writer, 0);
                    WriteInt32(writer, pre.id);
                    if(pre.type == 1)
                        WriteByte(writer, 1);
                    else if(pre.type == 0)
                        WriteByte(writer, 0);
                }
                
                for (int j = 0; j < template.SkillLearnList[i].prePassive.Count; j++)
                {
                    Skill_Template pre = Skill_Template.getTemplateById(template.SkillLearnList[i].prePassive[j]);
                    if(pre == null)
                        Console.WriteLine(2);
                    writetoPos(writer, countPos, (short) writer.BaseStream.Position);
                    WriteInt16(writer, (short) writer.BaseStream.Position);
                    countPos = (short) writer.BaseStream.Position;
                    WriteInt16(writer, 0);
                    WriteInt32(writer, pre.id);
                    if(pre.type == 1)
                        WriteByte(writer, 1);
                    else if(pre.type == 0)
                        WriteByte(writer, 0);
                }
                
                for (int j = 0; j < template.SkillLearnList[i].preSkill.Count; j++)
                {
                    Skill_Template pre = Skill_Template.getTemplateById(template.SkillLearnList[i].preSkill[j]);
                    if(pre == null)
                        Console.WriteLine(3);
                    writetoPos(writer, countPos, (short) writer.BaseStream.Position);
                    WriteInt16(writer, (short) writer.BaseStream.Position);
                    countPos = (short) writer.BaseStream.Position;
                    WriteInt16(writer, 0);
                    WriteInt32(writer, pre.id);
                    if(pre.type == 1)
                        WriteByte(writer, 1);
                    else if(pre.type == 0)
                        WriteByte(writer, 0);
                }
                
            }
        }
    }
}