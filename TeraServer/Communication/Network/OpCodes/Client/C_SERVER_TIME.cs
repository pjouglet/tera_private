using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_SERVER_TIME : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_SERVER_TIME sServerTime = new S_SERVER_TIME();
            sServerTime.Send(this.Connection);
        }
    }
}