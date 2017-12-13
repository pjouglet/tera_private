using System;
using System.Text;
using TeraServer.Communication.Network.OpCodes.Server;
using TeraServer.Utils;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_LOGIN_ARBITER : AClientPacket
    {
        private string username = string.Empty;
        private string ticket = string.Empty;
        private int language;
        private int patchVersion;
        
        public override void Read()
        {
            int nameOffset = ReadH();
            int ticketOffset = ReadH();
            int ticketSize = ReadH();
            byte[] unk3 = ReadB(1);
            int unk4 = ReadD();
            this.language = ReadD();
            this.patchVersion = ReadD();
            this.username = ReadS();
            byte[] ticket = ReadB(ticketSize);
            this.ticket = Encoding.UTF8.GetString(ticket, 0, ticket.Length);
        }

        public override void Process()
        {
            Communication.Logic.AccountLogic.AuthorizeLogin(this.Connection, this.username, this.ticket, this.language);
        }
    }
}