using System;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class C_ADMIN_GM_TELEPORT : AClientPacket
    {
        private int continent;
        private float x;
        private float y;
        private float z;
        public override void Read()
        {
            ReadH();
            continent = ReadH();
            ReadH();
            x = ReadF();
            y = ReadF();
            z = ReadF();
            
            Console.WriteLine("ID : {0}, X : {1}, Y : {2}, Z : {3} ", continent, x, y, z);
        }

        public override void Process()
        {
            this.Connection.player.posX = x;
            this.Connection.player.posY = y;
            this.Connection.player.posZ = z;
            this.Connection.player.continentId = continent;
            S_LOAD_TOPO sLoadTopo = new S_LOAD_TOPO(this.Connection.player);
            sLoadTopo.Send(this.Connection);
        }
    }
}