using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_REIGN_INFO : AClientPacket
    {
        private int info;
        public override void Read()
        {
            this.info = ReadD();
        }

        public override void Process()
        {
            S_REIGN_INFO sReignInfo = new S_REIGN_INFO(this.info);
            sReignInfo.Send(this.Connection);
        }
    }
}