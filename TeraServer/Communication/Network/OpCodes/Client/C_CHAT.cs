using System;
using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_CHAT : AClientPacket
    {
        private int channel;
        private string message;
        public override void Read()
        {
            ReadH();
            this.channel = ReadD();
            this.message = ReadS();
        }

        public override void Process()
        {
            Console.WriteLine("msg : " + this.message);
            S_CHAT sChat = new S_CHAT(this.channel, this.message, this.Connection.player);
            sChat.Send(this.Connection);
        }
    }
}