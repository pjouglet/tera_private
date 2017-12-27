namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_GUARD_PK_POLICY : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_GUARD_PK_POLICY sGuardPkPolicy = new S_GUARD_PK_POLICY();
            sGuardPkPolicy.Send(this.Connection);
        }
    }
}