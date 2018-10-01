using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_PLAYER_STAT_UPDATE : AServerPacket
    {
        private Player _player;

        public S_PLAYER_STAT_UPDATE(Player player)
        {
            this._player = player;
            
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, _player.playerStats.hp);
            WriteInt32(writer, _player.playerStats.mp);
            WriteInt32(writer, 0);
            WriteInt32(writer, _player.playerStats.maxHp);
            WriteInt32(writer, _player.playerStats.maxMp);
            WriteInt32(writer, _player.playerStats.power);
            WriteInt32(writer, _player.playerStats.endurance);
            WriteInt32(writer, _player.playerStats.impactFactor);
            WriteInt32(writer, _player.playerStats.balanceFactor);
            WriteInt16(writer, _player.playerStats.movementSpeed);
            WriteInt16(writer, _player.playerStats.walkSpeed);
            WriteInt16(writer, _player.playerStats.attackSpeed);
            WriteFloat(writer, _player.playerStats.critRate);
            WriteFloat(writer, _player.playerStats.critResist);
            WriteFloat(writer, _player.playerStats.critPower);
            WriteInt32(writer, _player.playerStats.attack);
            WriteInt32(writer, _player.playerStats.attack2);
            WriteInt32(writer, _player.playerStats.defence);
            WriteInt32(writer, _player.playerStats.impact);
            WriteInt32(writer, _player.playerStats.balance);
            WriteFloat(writer, _player.playerStats.resistWeakening);
            WriteFloat(writer, _player.playerStats.resistPeriodic);
            WriteFloat(writer, _player.playerStats.resistStun);
            WriteInt32(writer, _player.playerStats.powerBonus);
            WriteInt32(writer, _player.playerStats.enduranceBonus);
            WriteInt32(writer, _player.playerStats.impactFactorBonus);
            WriteInt32(writer, _player.playerStats.balanceBonus);
            WriteInt16(writer, _player.playerStats.runSpeedBonus);
            WriteInt16(writer, _player.playerStats.walkSpeedBonus);
            WriteInt16(writer, _player.playerStats.attackSpeedBonus);
            WriteFloat(writer, _player.playerStats.critRateBonus);
            WriteFloat(writer, _player.playerStats.critResistBonus);
            WriteFloat(writer, _player.playerStats.critPowerBonus);
            WriteInt32(writer, _player.playerStats.attackBonus);
            WriteInt32(writer, _player.playerStats.attack2Bonus);
            WriteInt32(writer, _player.playerStats.defenceBonus);
            WriteInt32(writer, _player.playerStats.impactBonus);
            WriteInt32(writer, _player.playerStats.balanceBonus);
            WriteFloat(writer, _player.playerStats.resistWeakeningBonus);
            WriteFloat(writer, _player.playerStats.resistPeriodicBonus);
            WriteFloat(writer, _player.playerStats.resistStunBonus);
            WriteInt16(writer, (short)_player.level);
            WriteByte(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, _player.playerStats.hpBonus);
            WriteInt32(writer, _player.playerStats.mpBonus);
            WriteInt32(writer, _player.playerStats.condition);
            WriteInt32(writer, _player.playerStats.conditionMax);
            WriteInt32(writer, _player.playerStats.stamina);
            WriteInt32(writer, _player.playerStats.staminaMax);
            WriteInt32(writer, _player.playerStats.staminaBonus);
            WriteInt32(writer, _player.playerStats.infamy);
            WriteInt32(writer, 110);//itemlevelInventory
            WriteInt32(writer, 100);//itemlevel
            WriteInt32(writer, _player.playerStats.edge);
            WriteInt16(writer, 0);
            WriteInt16(writer, 0);
            WriteInt32(writer, 8000);
            WriteInt32(writer, 3);
            WriteInt32(writer, _player.level);
            WriteFloat(writer, _player.playerStats.flightEnergy);
            WriteInt32(writer, 0);
            WriteFloat(writer, 1);
            
        }
    }
}