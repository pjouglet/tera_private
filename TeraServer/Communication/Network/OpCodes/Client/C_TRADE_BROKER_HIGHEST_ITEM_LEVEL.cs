using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_TRADE_BROKER_HIGHEST_ITEM_LEVEL : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_TRADE_BROKER_HIGHEST_ITEM_LEVEL sTradeBrokerHighestItemLevel = new S_TRADE_BROKER_HIGHEST_ITEM_LEVEL();
            sTradeBrokerHighestItemLevel.Send(this.Connection);
        }
    }
}