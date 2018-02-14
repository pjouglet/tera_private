using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_PLAYER_CHANGE_ALL_PROF : AServerPacket
    {
        private Player _player;
        
        public S_PLAYER_CHANGE_ALL_PROF(Player player)
        {
            this._player = player;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer,(short) _player.playerStats.gatheringEnergy);//base energy
            WriteInt16(writer, (short) _player.playerStats.gatheringHerb);//base herb
            WriteInt16(writer, 0);//base bug
            WriteInt16(writer, (short) _player.playerStats.gatheringMineral);//base mineral
            WriteInt16(writer, (short) _player.playerStats.bonusEnergy);//bonus
            WriteInt16(writer, (short) _player.playerStats.bonusHerb);//bonus
            WriteInt16(writer, 0);//bonus
            WriteInt16(writer, (short) _player.playerStats.bonusMineral);//bonus
        }
    }
}