using System;
using System.Collections.Generic;
using TeraServer.Data.Structures.Enums;

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
    public class Player
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
        
        

        public Achievements Achievements;

        public int model
        {
            get { return 10101 + 200 * (int)race + 100 * (int)gender + (int)classId; }
        }

        public void Release()
        {
            //todo do release
        }

        public void updateStats()
        {
            if (this.playerStats.hp < this.playerStats.maxHp)
                if (this.playerStats.hp + 1000 > this.playerStats.maxHp)
                    this.playerStats.hp = this.playerStats.maxHp;
                else
                    this.playerStats.hp += 1000;
            
            if (this.playerStats.mp < this.playerStats.maxMp)
                if (this.playerStats.mp + 500 > this.playerStats.maxMp)
                    this.playerStats.mp = this.playerStats.maxMp;
                else
                    this.playerStats.mp += 500;
            
            if (this.playerStats.stamina < this.playerStats.staminaMax)
                if (this.playerStats.stamina + 100 > this.playerStats.staminaMax)
                    this.playerStats.stamina = this.playerStats.staminaMax;
                else
                    this.playerStats.stamina += 100;
            
        }
        
    }
}