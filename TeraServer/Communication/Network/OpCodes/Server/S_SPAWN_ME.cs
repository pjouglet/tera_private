using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SPAWN_ME : AServerPacket
    {
        private Player _player;
        public S_SPAWN_ME(Player player)
        {
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            writeWorldId(writer, this._player);
            WriteFloat(writer, this._player.posX);
            WriteFloat(writer, this._player.posY);
            WriteFloat(writer, this._player.posZ);
            WriteInt16(writer, (short)this._player.heading);
            WriteByte(writer, 1);//alive
            WriteByte(writer, 0);
        }
    }
}