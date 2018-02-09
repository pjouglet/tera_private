using System;
using System.Collections.Generic;
using System.Threading;
using TeraServer.Communication.Network;
using TeraServer.Communication.Network.OpCodes.Server;
using TeraServer.Data.Structures.Enums;
using TeraServer.Data.Structures.Templates;

namespace TeraServer.Data.Structures
{
    public struct bookmark
    {
        public int continent;
        public float x;
        public float y;
        public float z;
        public string name;
    }
    public class Player : Uid
    {
        public int playerId;
        public string name = String.Empty;
        public float posX;
        public float posY;
        public float posZ;
        public int heading;
        public Player_Race race;
        public Player_Gender gender;
        public Player_Class classId;
        public int xp;
        public int restedXp;
        public int areaId;
        public int continentId;
        public int level;
        public int title;
        public byte[] details1;
        public byte[] details2;
        public byte[] details3;
        public int lastOnline;
        public int creationTime;
        public int worldMapGuardId;
        public int worldMapWorldId;
        public int worldMapSectionId;
        public int lobbyPosition;
        public int GM;
        public byte[] accountSettings;
        public List<bookmark> AdminBookmarks = new List<bookmark>();
        public Stats playerStats;
        public List<Skill_Template> learnedSkills = new List<Skill_Template>();
        
        

        public Achievements Achievements;

        public int model
        {
            get { return 10101 + 200 * (int)race + 100 * (int)gender + (int)classId; }
        }

        public void Release()
        {
            //todo do release
            base.Release();
        }

        public void updateStats(Connection connection)
        {
            if (this.playerStats.hp < this.playerStats.maxHp)
            {
                long diff = 0;
                if (this.playerStats.hp + 1000 > this.playerStats.maxHp)
                    diff = this.playerStats.maxHp - this.playerStats.hp;
                else
                    diff = 1000;
                this.playerStats.hp = this.playerStats.hp + (int)diff;
                S_CREATURE_CHANGE_HP sCreatureChangeHp = new S_CREATURE_CHANGE_HP(this, diff);
                sCreatureChangeHp.Send(connection);
            }

            if (this.playerStats.mp < this.playerStats.maxMp)
            {
                int diff = 0;
                if (this.playerStats.mp + 500 > this.playerStats.maxMp)
                    diff = this.playerStats.maxMp - this.playerStats.mp;
                else
                    diff = 500;
                this.playerStats.mp = this.playerStats.mp + diff;
                S_PLAYER_CHANGE_MP sPlayerChangeMp = new S_PLAYER_CHANGE_MP(this, diff);
                sPlayerChangeMp.Send(connection);
            }


            if (this.playerStats.stamina < this.playerStats.staminaMax)
            {
                if (this.playerStats.stamina + 100 > this.playerStats.staminaMax)
                    this.playerStats.stamina = this.playerStats.staminaMax;
                else
                    this.playerStats.stamina += 100;
                S_PLAYER_CHANGE_STAMINA sPlayerChangeStamina = new S_PLAYER_CHANGE_STAMINA(this);
                sPlayerChangeStamina.Send(connection);
            }
                
            
        }

        public bool learnSkill(int skillId)
        {
            Skill_Template template = Skill_Template.getTemplateById(skillId);
            Class_Template classTemplate = Class_Template.ClassTemplates[Convert.ToInt32(classId)];
            for (int x = 0; x < classTemplate.SkillLearnList.Count; x++)
            {
                if (classTemplate.SkillLearnList[x].id == template.id)
                {
                    if (learnedSkills.Contains(template))
                        return false;


                    bool canLearn = true;
                    for (int i = 0; i < template.preSkill.Count; i++)
                    {
                        Skill_Template pre = Skill_Template.getTemplateById(template.preSkill[i]);
                        if (!learnedSkills.Contains(pre))
                            canLearn = false;
                    }

                    if (canLearn)
                    {
                        if (template.overridePreviousSkill == 1)
                        {
                            for (int i = 0; i < template.preSkill.Count; i++)
                            {
                                Skill_Template pre = Skill_Template.getTemplateById(template.preSkill[i]);
                                if (learnedSkills.Contains(pre))
                                    learnedSkills.Remove(pre);
                            }
                        }
                        learnedSkills.Add(template);
                    }
                    return true;
                }
            }
            return false;
        }

        public void startSkill(int skillId, Connection connection)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                Thread.Sleep(750);
                S_ACTION_END sActionEnd = new S_ACTION_END(this, this.posX, this.posY, this.posZ, (short) this.heading,
                    skillId, 0);
                sActionEnd.Send(connection);
                Thread.Sleep(750);
            });
        }
        
    }
}