using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_UPDATE_NPCGUILD : AServerPacket
    {
        private Player _player;
        public S_UPDATE_NPCGUILD(Player player)
        {
            this._player = player;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, this._player.playerId);
            WriteInt32(writer, 0);
            WriteInt32(writer, 1);
            WriteInt32(writer, 9);
            WriteInt32(writer, 610);
            WriteInt32(writer, 6);
            WriteLong(writer, 0);
        }
    }
}