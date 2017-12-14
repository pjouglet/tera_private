using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_CHECK_USERNAME : AClientPacket
    {
        private string username;
        public override void Read()
        {
            short nameOffset = (short)ReadH();
            this.username = ReadS();
        }

        public override void Process()
        {
            S_CHECK_USERNAME sCheckUsername = new S_CHECK_USERNAME(this.username);
            sCheckUsername.Send(this.Connection);
        }
    }
}