using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_USER_LOCATION : AServerPacket
    {
        private Player _player;
        private float x;
        private float y;
        private float z;
        private float tx;
        private float ty;
        private float tz;
        private int heading;
        private int type;
        private short speed;

        public S_USER_LOCATION(Player player, float x, float y, float z, float tx, float ty, float tz, int heading,
            int type, int speed)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.tx = tx;
            this.ty = ty;
            this.tz = tz;
            this.heading = heading;
            this.type = type;
            this.speed = (short) speed;
        }
        
        public override void Write(BinaryWriter writer)
        {
            writeWorldId(writer, this._player);
            WriteFloat(writer, this.x);
            WriteFloat(writer, this.y);
            WriteFloat(writer, this.z);
            WriteInt32(writer, this.heading);
            WriteInt16(writer, 70);//todo : speed with stat update
            WriteFloat(writer, this.tx);
            WriteFloat(writer, this.ty);
            WriteFloat(writer, this.tz);
            WriteInt32(writer, this.type);
            WriteByte(writer, 1);
        }
    }
}