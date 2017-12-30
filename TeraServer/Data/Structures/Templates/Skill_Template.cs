using System;
using System.Collections.Generic;
using System.Xml;
using TeraServer.Data.Structures.Enums;

namespace TeraServer.Data.Structures.Templates
{
    public class Skill_Template
    {
        public static List<Skill_Template> SkillTemplates;
        public Player_Class PlayerClass;
        public int id;
        public short level;
        public int type;
        public int cost;
        public string learnType;
        public List<int> preSkill = new List<int>();
        public List<int> preActive = new List<int>();
        public List<int> prePassive = new List<int>();

        public static void LoadSkills()
        {
            SkillTemplates = new List<Skill_Template>();

            try
            {
                XmlDocument document = new XmlDocument();      
                document.Load(@"data/skills_learn.xml");
                XmlNodeList nodeList = document.SelectNodes("skills_learn_list/class");
                foreach (XmlNode node in nodeList)
                {
                    Player_Class _class = Player_Class.COMMON;
                    foreach (XmlAttribute attribute in node.Attributes)
                        if (attribute.Name == "id")
                            _class = (Player_Class) Convert.ToInt32(attribute.Value);
                    
                    XmlNodeList skilList = node.SelectNodes("./skill");
                    foreach (XmlNode skill in skilList)
                    {
                        Skill_Template template = new Skill_Template();
                        template.PlayerClass = _class;
                        foreach (XmlAttribute attribute in skill.Attributes)
                        {
                            if (attribute.Name == "id")
                                template.id = Convert.ToInt32(attribute.Value);
                            if (attribute.Name == "level")
                                template.level = Convert.ToInt16(attribute.Value);
                            if (attribute.Name == "type")
                                template.type = Convert.ToInt32(attribute.Value);
                            if (attribute.Name == "cost")
                                template.cost = Convert.ToInt32(attribute.Value);
                            if (attribute.Name == "learnType")
                                template.learnType = attribute.Value;
                        }
                        
                        XmlNodeList preActive = skill.SelectNodes("./preactive");
                        foreach (XmlNode activeNode in preActive)
                            foreach (XmlAttribute attr in activeNode.Attributes)
                                template.preActive.Add(Convert.ToInt32(attr.Value));
                        
                        XmlNodeList prePassive = skill.SelectNodes("./prepassive");
                        foreach (XmlNode activeNode in prePassive)
                            foreach (XmlAttribute attr in activeNode.Attributes)
                                template.prePassive.Add(Convert.ToInt32(attr.Value));
                        XmlNodeList preSkill = skill.SelectNodes("./preskill");
                        foreach (XmlNode activeNode in preSkill)
                            foreach (XmlAttribute attr in activeNode.Attributes)
                                template.preSkill.Add(Convert.ToInt32(attr.Value));
                        SkillTemplates.Add(template);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when trying to load skills " + e.Message);
                throw;
            }
        }

        public static Skill_Template getTemplateById(int skillId)
        {
            for (int i = 0; i < SkillTemplates.Count; i++)
            {
                if (SkillTemplates[i].id == skillId)
                    return SkillTemplates[i];
            }
            Console.WriteLine("Unknow skill ID : " + skillId);
            return null;
        }

        public static List<Skill_Template> getTemplatesByClass(Player_Class classId)
        {
            List<Skill_Template> list = new List<Skill_Template>();
            for (int i = 0; i < SkillTemplates.Count; i++)
            {
                if(SkillTemplates[i].PlayerClass == classId)
                    list.Add(SkillTemplates[i]);
            }
            return list;
        }
    }
}