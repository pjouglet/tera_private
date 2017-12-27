using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_INGAMESHOP_PRODUCT_END : AServerPacket
    {
        private byte product;

        public S_INGAMESHOP_PRODUCT_END(byte product)
        {
            this.product = product;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteByte(writer, product);
        }
    }
}