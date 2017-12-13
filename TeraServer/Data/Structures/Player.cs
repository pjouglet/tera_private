using System;

namespace TeraServer.Data.Structures
{
    public class Player
    {
        public int playerId;
        public string name = String.Empty;
        public double posX;
        public double posY;
        public double posZ;
        public int heading;
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
        public long lastOnline;
        public long creationTime;
        public int worldMapGuardId;
        public int worldMapWorldId;
        public int worldMapSectionId;
        public int lobbyPosition;
        
        public void Release()
        {
            //todo do release
        }
    }
}