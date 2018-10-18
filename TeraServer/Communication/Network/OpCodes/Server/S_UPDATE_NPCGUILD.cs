using System.IO;
using TeraServer.Data.Structures;
using TeraServer.Data.Structures.Enums;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_UPDATE_NPCGUILD : AServerPacket
    {
        private Player _player;
        private int _region;
        private int _faction;
        private int _reputation;
        private int _credits;
        private Player_Reputation _playerReputation;
        
        public S_UPDATE_NPCGUILD(Player player, int region, int faction, int reputation, int credits, Player_Reputation playerReputation)
        {
            this._player = player;
            this._region = region;
            this._faction = faction;
            this._reputation = reputation;
            this._credits = credits;
            this._playerReputation = playerReputation;
        }
        public override void Write(BinaryWriter writer)
        {
            writeWorldId(writer, this._player);
            WriteInt32(writer, 2);//unk
            WriteInt32(writer, this._region);
            WriteInt32(writer, this._faction);
            WriteInt32(writer, (int) this._playerReputation);
            WriteInt32(writer, this._reputation);
            WriteInt32(writer, this._credits);
        }
    }
}