using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_REQUEST_VIP_SYSTEM_INFO : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_SEND_VIP_SYSTEM_INFO sSendVipSystemInfo = new S_SEND_VIP_SYSTEM_INFO(this.Connection.Account);
            sSendVipSystemInfo.Send(this.Connection);
        }
    }
}