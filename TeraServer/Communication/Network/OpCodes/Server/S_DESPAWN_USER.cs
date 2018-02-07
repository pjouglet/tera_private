using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_DESPAWN_USER : AServerPacket
    {
        private Player _player;
        private int type;
        
        public S_DESPAWN_USER(Player player, int type)
        {
            this._player = player;
            this.type = type;
        }
        
        public override void Write(BinaryWriter writer)
        {
            writeWorldId(writer, this._player);
            WriteInt32(writer, this.type);
        }
    }
}