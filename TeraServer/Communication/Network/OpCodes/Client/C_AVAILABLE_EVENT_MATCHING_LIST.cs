using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_AVAILABLE_EVENT_MATCHING_LIST : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_AVAILABLE_EVENT_MATCHING_LIST sAvailableEventMatchingList = new S_AVAILABLE_EVENT_MATCHING_LIST();
            sAvailableEventMatchingList.Send(this.Connection);
        }
    }
}