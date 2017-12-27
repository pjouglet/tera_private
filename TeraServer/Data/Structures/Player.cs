using System;

namespace TeraServer.Data.Structures
{
    public class Player
    {
        public int playerId;
        public string name = String.Empty;
        public float posX;
        public float posY;
        public float posZ;
        public int heading;
        public int race;
        public int gender;
        public int classId;
        public int xp;
        public int restedXp;
        public int areaId;
        public int continentId;
        public int level;
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

        public int model
        {
            get { return 10101 + 200 * race + 100 * gender + classId; }
        }

        public void Release()
        {
            //todo do release
        }
        
    }
}