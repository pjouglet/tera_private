using System;
using System.Collections.Generic;
using System.Xml;
using TeraServer.Data.Structures.Enums;

namespace TeraServer.Data.Structures.Templates
{
    public class Race_Template
    {
        public static List<Race_Template> RaceTemplates;
        public Player_Race race;
        public List<Skill_Template> baseRaceSkills = new List<Skill_Template>();

        public static void LoadTemplates()
        {
            RaceTemplates = new List<Race_Template>();
            try
            {
                XmlDocument document = new XmlDocument();      
                document.Load(@"data/templates/race.xml");
                XmlNodeList nodeList = document.SelectNodes("race_templates_list/race");
                foreach (XmlNode node in nodeList)
                {
                    Race_Template template = new Race_Template();

                    foreach (XmlAttribute attribute in node.Attributes)
                    {
                        if (attribute.Name == "id")
                            template.race = (Player_Race) Convert.ToInt32(attribute.Value);
                    }
                    
                    XmlNodeList skilList = node.SelectNodes("./skills");
                    foreach (XmlNode skills in skilList)
                    {
                        XmlNodeList skillList = skills.SelectNodes("./skill");
                        foreach (XmlNode skill in skillList )
                        {
                            foreach (XmlAttribute attr in skill.Attributes)
                            {
                                if (attr.Name == "id")
                                {
                                    Skill_Template skillTemplate = Skill_Template.getTemplateById(Convert.ToInt32(attr.Value));
                                    template.baseRaceSkills.Add(skillTemplate);
                                }
                                    
                            }
                        }
                    }
                    RaceTemplates.Add(template);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when trying to load Rrace templates "+  e.Message);
                throw;
            }
        }
    }
}