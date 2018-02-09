using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_CREATURE_CHANGE_HP : AServerPacket
    {
        private Player _player;
        private long _diff;
        private byte _crit;
        private int _abnId;
        
        public S_CREATURE_CHANGE_HP(Player player, long diff, byte crit = 0, int abn_id = 0)
        {
            this._player = player;
            this._diff = diff;
            this._crit = crit;
            this._abnId = abn_id;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteLong(writer, _player.playerStats.hp);
            WriteLong(writer, _player.playerStats.maxHp);
            WriteLong(writer, _diff);
            WriteInt32(writer, 3);
            WriteLong(writer, _player.UID);
            WriteLong(writer, 0);
            WriteByte(writer, _crit);
            WriteInt32(writer, _abnId);
        }
    }
}