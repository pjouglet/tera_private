using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_PLAYER_CHANGE_STAMINA : AServerPacket
    {
        private Player _player;
        
        public S_PLAYER_CHANGE_STAMINA(Player player)
        {
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, _player.playerStats.stamina);
            WriteInt32(writer, _player.playerStats.staminaMax);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
        }
    }
}