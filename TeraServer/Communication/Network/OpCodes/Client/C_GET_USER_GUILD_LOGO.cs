using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_GET_USER_GUILD_LOGO : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_GET_USER_GUILD_LOGO sGetUserGuildLogo = new S_GET_USER_GUILD_LOGO();
            sGetUserGuildLogo.Send(this.Connection);
        }
    }
}