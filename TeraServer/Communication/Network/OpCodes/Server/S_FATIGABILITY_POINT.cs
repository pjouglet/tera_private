using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_FATIGABILITY_POINT : AServerPacket
    {
        private Player _player;
        public S_FATIGABILITY_POINT(Player player)
        {
            this._player = player;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 1);
            WriteInt32(writer, this._player.playerStats.fatigability);
        }
    }
}