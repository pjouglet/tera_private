using System;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_START_SKILL : AClientPacket
    {
        private int skill;
        private short heading;
        private float x;
        private float y;
        private float z;
        private float toX;
        private float toY;
        private float toZ;
        private byte moving;
        private byte continuePrevious;
        private long target;
        
        public override void Read()
        {
            this.skill =ReadD() - 0x4000000;
            this.heading = (short)ReadH();
            this.x = ReadF();
            this.y = ReadF();
            this.z = ReadF();

            this.toX = ReadF();
            this.toY = ReadF();
            this.toZ = ReadF();
            ReadB(1);

            this.moving = ReadB(1)[0];
            this.continuePrevious = ReadB(1)[0];
            this.target = ReadD();
            
            Console.WriteLine("Skill {0} to target {1}", skill, target);
        }

        public override void Process()
        {
            
        }
    }
}