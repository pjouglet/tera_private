using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_LOAD_TOPO : AServerPacket
    {
        private Player _player;
        public S_LOAD_TOPO(Player player)
        {
            this._player = player;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, _player.continentId);
            WriteFloat(writer, _player.posX);
            WriteFloat(writer, _player.posY);
            WriteFloat(writer, _player.posZ);
        }
    }
}