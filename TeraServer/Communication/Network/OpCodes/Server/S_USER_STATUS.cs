using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_USER_STATUS : AServerPacket
    {
        private Player _player;

        public S_USER_STATUS(Player player)
        {
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            writeWorldId(writer, this._player);
            WriteInt32(writer, 0);
            WriteByte(writer, 0);
        }
    }
}