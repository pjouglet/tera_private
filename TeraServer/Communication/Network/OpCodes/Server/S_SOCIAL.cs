using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SOCIAL : AServerPacket
    {
        private Player _player;
        private int _emoteId;
        
        public S_SOCIAL(Player player, int emoteId)
        {
            this._player = player;
            this._emoteId = emoteId;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteLong(writer, _player.UID);
            WriteInt32(writer, _emoteId);
            WriteInt32(writer, 0);
            WriteByte(writer, 0);
        }
    }
}