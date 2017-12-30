using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SPAWN_NPC : AServerPacket
    {
        private int val1;
        private int val2;
        private int val3;
        private int val4;
        private Player _player;
        
        public S_SPAWN_NPC(Player player, int val1, int val2, int val3, int val4)
        {
            this._player = player;
            this.val1 = val1;
            this.val2 = val2;
            this.val3 = val3;
            this.val4 = val4;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteLong(writer, 0);
            WriteInt32(writer, 5000);//eid
            WriteInt32(writer, 1096);
            WriteInt32(writer, 12);
            WriteInt32(writer, 0);
            WriteInt16(writer, 1);
            WriteFloat(writer, _player.posX);
            WriteFloat(writer, _player.posY);
            WriteFloat(writer, _player.posZ);
            WriteInt16(writer, (short) _player.heading);
            WriteInt32(writer, 16);
            WriteInt32(writer, val2);
            WriteInt32(writer, val1);
            WriteInt32(writer, 110);
            WriteInt16(writer, 60);
            WriteInt32(writer, 5);
            WriteInt16(writer, 1);
            
            WriteByte(writer, 1);
            WriteByte(writer, 0);
            WriteInt32(writer, 1);
            WriteLong(writer, 0);
            WriteInt16(writer, 0);
            WriteInt16(writer, 0);
            WriteInt32(writer, 0);
            WriteByte(writer, 0);
            WriteLong(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteLong(writer, 0);
            WriteByte(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 49821);
        }
    }
}