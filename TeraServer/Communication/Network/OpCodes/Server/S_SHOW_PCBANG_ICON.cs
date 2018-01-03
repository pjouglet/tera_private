using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SHOW_PCBANG_ICON : AServerPacket
    {
        private byte active;
        private Player _player;

        public S_SHOW_PCBANG_ICON(byte active, Player player)
        {
            this.active = active;
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            writeWorldId(writer, this._player);
            WriteByte(writer, this.active);
        }
    }
}