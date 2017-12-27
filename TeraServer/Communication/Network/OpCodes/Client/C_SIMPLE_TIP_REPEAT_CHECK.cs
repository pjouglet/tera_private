using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_SIMPLE_TIP_REPEAT_CHECK : AClientPacket
    {
        private int tip;
        public override void Read()
        {
            this.tip = ReadD();
        }

        public override void Process()
        {
            S_SIMPLE_TIP_REPEAT_CHECK simpleTipRepeatCheck = new S_SIMPLE_TIP_REPEAT_CHECK(this.tip);
            simpleTipRepeatCheck.Send(this.Connection);
        }
    }
}