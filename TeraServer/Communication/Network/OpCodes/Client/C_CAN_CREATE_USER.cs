using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_CAN_CREATE_USER : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_CAN_CREATE_USER s_can_create_user = new S_CAN_CREATE_USER();
            s_can_create_user.Send(this.Connection);
        }
    }
}