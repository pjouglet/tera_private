using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_PLAYER_CHANGE_MP : AServerPacket
    {
        private Player _player;
        private int _diff;
        
        public S_PLAYER_CHANGE_MP(Player player, int diff)
        {
            this._player = player;
            this._diff = diff;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, _player.playerStats.mp);
            WriteInt32(writer, _player.playerStats.maxMp);
            WriteInt32(writer, _diff);
            WriteInt32(writer, 2);
            WriteLong(writer, _player.UID);
            WriteLong(writer, 0);
        }
    }
}