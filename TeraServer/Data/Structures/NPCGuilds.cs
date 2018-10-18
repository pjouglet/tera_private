using System;
using System.Collections.Generic;
using System.Xml;
using TeraServer.Data.Structures.Enums;

namespace TeraServer.Data.Structures
{
    public class NPCGuilds
    {
        public static List<NPCGuilds> NpcGuildsList = new List<NPCGuilds>();

        public int region;
        public int faction;
        public int reputation;
        public int credits;
        public Player_Reputation PlayerReputation;
        public int maxCredits;


        public NPCGuilds()
        {
            
        }

        public static void LoadNPCGuildFromFile()
        {
            try
            {
                XmlDocument document = new XmlDocument();      
                document.Load(@"data/reputation.xml");
                XmlNodeList nodeList = document.SelectNodes("reputation_list/reputation");
                foreach (XmlNode node in nodeList)
                {
                    NPCGuilds npcGuilds = new NPCGuilds();
                    foreach (XmlAttribute attribute in node.Attributes)
                    {
                        if (attribute.Name == "region")
                            npcGuilds.region = Convert.ToInt32(attribute.Value);
                        if (attribute.Name == "faction")
                            npcGuilds.faction = Convert.ToInt32(attribute.Value);
                        if (attribute.Name == "maxCredits")
                            npcGuilds.maxCredits = Convert.ToInt32(attribute.Value);
                    }
                    
                    NPCGuilds.NpcGuildsList.Add(npcGuilds);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when trying to load NPCGuilds file !" + ex.Message);  
            }
        }
    }
}