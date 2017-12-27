using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_INGAMESHOP_PRODUCT_BEGIN : AServerPacket
    {
        private byte product;

        public S_INGAMESHOP_PRODUCT_BEGIN(byte product)
        {
            this.product = product;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteByte(writer, product);
        }
    }
}