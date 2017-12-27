using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class C_REQUEST_INGAMESTORE_PRODUCT_LIST : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_INGAMESHOP_CATEGORY_BEGIN sIngameshopCategoryBegin = new S_INGAMESHOP_CATEGORY_BEGIN(1);
            sIngameshopCategoryBegin.Send(this.Connection);
            
            S_INGAMESHOP_CATEGORY_END sIngameshopCategoryEnd = new S_INGAMESHOP_CATEGORY_END(1);
            sIngameshopCategoryEnd.Send(this.Connection);
            
            S_INGAMESHOP_PRODUCT_BEGIN sIngameshopProductBegin = new S_INGAMESHOP_PRODUCT_BEGIN(1);
            sIngameshopProductBegin.Send(this.Connection);
            
            S_INGAMESHOP_PRODUCT_END sIngameshopProductEnd = new S_INGAMESHOP_PRODUCT_END(1);
            sIngameshopProductEnd.Send(this.Connection);
        }
    }
}