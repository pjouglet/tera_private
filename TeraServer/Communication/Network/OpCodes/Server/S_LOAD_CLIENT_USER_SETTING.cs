using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_LOAD_CLIENT_USER_SETTING : AServerPacket
    {
        private Player _player;
        public S_LOAD_CLIENT_USER_SETTING(Player player)
        {
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 8);
            WriteInt16(writer, (short)this._player.accountSettings.Length);
            WriteBytes(writer, this._player.accountSettings);
        }
    }
}