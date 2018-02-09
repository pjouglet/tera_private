using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_SOCIAL : AClientPacket
    {
        private int emoteId;
        public override void Read()
        {
            this.emoteId = ReadD();
        }

        public override void Process()
        {
            S_CHAT sChat = new S_CHAT(26, "@social:10" + this.emoteId.ToString(), this.Connection.player);
            Network.Connection.broadcast(sChat);
            
            S_SOCIAL sSocial = new S_SOCIAL(this.Connection.player, this.emoteId);
            Network.Connection.broadcast(sSocial);
        }
    }
}