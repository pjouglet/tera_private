using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Xml;

namespace TeraServer.Data.Structures
{
    public class Achievements
    {
        public class Requirements
        {
            public int id;
            public string description;
            public int type;
            public int template;
            public int max;
            public int value1;
        }
        
        public static List<Achievements> achievementList = new List<Achievements>();
        public List<Achievements> completed = new List<Achievements>();
        public List<Achievements> progress = new List<Achievements>();

        public int id;
        public string name;
        public int points;
        public int category;
        public List<Requirements> requirements = new List<Requirements>();

        public Achievements()
        {
            
        }

        public static void LoadAchievementsFromFile()
        {
            try
            {
                XmlDocument document = new XmlDocument();      
                document.Load(@"data/achievements.xml");
                XmlNodeList nodeList = document.SelectNodes("achievements_list/achievement");
                foreach (XmlNode node in nodeList)
                {
                    Achievements achievement = new Achievements();
                    foreach (XmlAttribute attribute in node.Attributes)
                    {
                        if (attribute.Name == "id")
                            achievement.id = Convert.ToInt32(attribute.Value);
                        if (attribute.Name == "name")
                            achievement.name = attribute.Value;
                        if (attribute.Name == "points")
                            achievement.points = Convert.ToInt32(attribute.Value);
                        if (attribute.Name == "category")
                            achievement.category = Convert.ToInt32(attribute.Value);
                    }
                    
                    XmlNodeList requirements = node.SelectNodes("./requirements");

                    foreach (XmlNode requirement in requirements)
                    {
                        Requirements req = new Requirements();
                        foreach (XmlAttribute attr in requirement.Attributes)
                        {
                           if (attr.Name == "id")
                                req.id = Convert.ToInt32(attr.Value);
                            if (attr.Name == "check")
                                req.type = (attr.Value == "check") ? 0 : 1;
                            if(attr.Name == "template")
                                req.template = Convert.ToInt32(attr.Value);
                        }
                        achievement.requirements.Add(req);
                            
                    }
                    Achievements.achievementList.Add(achievement);
                }
            }
            catch (Exception ex)
            {
                 Console.WriteLine("Error when trying to load achievement file !" + ex.Message);   
            }
            
            
        }

        public long getTotalPoints()
        {
            long points = 0;
            for (int i = 0; i < completed.Count; i++)
            {
                points += this.completed[i].points;
            }
            return points;
        }
    }
}