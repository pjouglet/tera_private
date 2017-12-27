using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_TRADE_BROKER_HIGHEST_ITEM_LEVEL : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 450);
        }
    }
}