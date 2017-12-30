namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class C_ADMIN_REQUEST_CUSTOM_BOOKMARK : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_ADMIN_CUSTOM_BOOKMARK_LIST sAdminCustomBookmarkList = new S_ADMIN_CUSTOM_BOOKMARK_LIST(this.Connection.player);
            //sAdminCustomBookmarkList.Send(this.Connection);
        }
    }
}