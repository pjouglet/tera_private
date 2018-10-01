using System;
using System.Threading;
using TeraServer.Communication.Network.OpCodes.Server;

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
        }

        public override void Process()
        {
            S_ACTION_STAGE sActionStage = new S_ACTION_STAGE(this.Connection.player, x, y, z, heading, toX, toY, toZ, skill, target);
            sActionStage.Send(this.Connection);
            if (this.skill == 200003)
            {
                S_ABNORMALITY_BEGIN sAbnormalityBegin = new S_ABNORMALITY_BEGIN(this.Connection.player, 903, 30000, 0);
                sAbnormalityBegin.Send(this.Connection);
            }
            
            this.Connection.player.startSkill(skill, this.Connection);
        }
    }
}