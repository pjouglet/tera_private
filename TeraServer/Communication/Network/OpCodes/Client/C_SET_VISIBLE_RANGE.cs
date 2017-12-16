namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_SET_VISIBLE_RANGE : AClientPacket
    {
        public override void Read()
        {
            int range = ReadD();
        }

        public override void Process()
        {
            
        }
    }
}