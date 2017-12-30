using System;
using System.Collections.Generic;
using System.Xml;
using TeraServer.Data.Structures.Enums;

namespace TeraServer.Data.Structures.Templates
{
    public class Class_Template
    {
        public static List<Class_Template> ClassTemplates = new List<Class_Template>();
        public Player_Class classId;
        public short startLevel;
        public int maxHp;
        public int maxMp;
        public int attackSpeed;
        public short movementSpeed;
        public short walkSpeed;
        public float critRate;
        public float critResist;
        public float critPower;
        public float stunRate;
        public float periodicRate;
        public float weakeningRate;
        public float weakeningResist;
        public float periodicResist;
        public float stunResist;
        public int maxStamina;
        public List<Skill_Template> SkillList = new List<Skill_Template>();
        public List<Skill_Template> SkillLearnList = new List<Skill_Template>();

        public static void LoadTemplates()
        {
            try
            {
                XmlDocument document = new XmlDocument();      
                document.Load(@"data/templates/class.xml");
                XmlNodeList nodeList = document.SelectNodes("class_templates_list/class");
                foreach (XmlNode node in nodeList)
                {
                    Class_Template template = new Class_Template();

                    foreach (XmlAttribute attribute in node.Attributes)
                    {
                        if (attribute.Name == "id")
                            template.classId = (Player_Class) Convert.ToInt32(attribute.Value);
                        if (attribute.Name == "startLevel")
                            template.startLevel = Convert.ToInt16(attribute.Value);
                    }
                        
                    
                    XmlNodeList statsList = node.SelectNodes("./stats");
                    foreach (XmlNode stats in statsList)
                    {
                        foreach (XmlAttribute stat in stats.Attributes)
                        {
                            if (stat.Name == "maxhp")
                                template.maxHp = Convert.ToInt32(stat.Value);
                            if (stat.Name == "maxmp")
                                template.maxMp = Convert.ToInt32(stat.Value);
                            if (stat.Name == "attackSpeed")
                                template.attackSpeed = Convert.ToInt32(stat.Value);
                            if (stat.Name == "movementSpeed")
                                template.movementSpeed = Convert.ToInt16(stat.Value);
                            if (stat.Name == "walkSpeed")
                                template.walkSpeed = Convert.ToInt16(stat.Value);
                            if (stat.Name == "critRate")
                                template.critRate = Convert.ToInt32(stat.Value);
                            if (stat.Name == "critResist")
                                template.critResist = Convert.ToInt32(stat.Value);
                            if (stat.Name == "critPower")
                                template.critPower = Convert.ToInt32(stat.Value);
                            if (stat.Name == "stunRate")
                                template.stunRate = Convert.ToInt32(stat.Value);
                            if (stat.Name == "periodicRate")
                                template.periodicRate = Convert.ToInt32(stat.Value);
                            if (stat.Name == "weakeningRate")
                                template.weakeningRate = Convert.ToInt32(stat.Value);
                            if (stat.Name == "weakeningResist")
                                template.weakeningResist = Convert.ToInt32(stat.Value);
                            if (stat.Name == "periodicResist")
                                template.periodicResist = Convert.ToInt32(stat.Value);
                            if (stat.Name == "stunResist")
                                template.stunResist = Convert.ToInt32(stat.Value);
                            if (stat.Name == "maxStamina")
                                template.maxStamina = Convert.ToInt32(stat.Value);
                        }
                    }
                    XmlNodeList skillsList = node.SelectNodes("./skills/skill");
                    foreach (XmlNode skills in skillsList)
                    {
                        foreach (XmlAttribute attribute in skills.Attributes)
                        {
                            if (attribute.Name == "id")
                            {
                                Skill_Template skillTemplate = Skill_Template.getTemplateById(Convert.ToInt32(attribute.Value));
                                if(skillTemplate != null)
                                    template.SkillList.Add(skillTemplate);
                            }
                        }
                        
                    }
                    template.SkillLearnList = Skill_Template.getTemplatesByClass(template.classId);
                    ClassTemplates.Add(template);
                }
            }
            catch (Exception ex)
            {
                 Console.WriteLine("Error when trying to load class templates file !" + ex.Message);   
            }
        }
    }
}