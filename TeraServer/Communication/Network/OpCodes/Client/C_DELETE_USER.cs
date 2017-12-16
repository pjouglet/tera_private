using TeraServer.Communication.Network.OpCodes.Server;
using TeraServer.Data.DAO;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_DELETE_USER : AClientPacket
    {
        private int id;
        public override void Read()
        {
            this.id = ReadD();
        }

        public override void Process()
        {
            DAOManager.PlayerDao.DeletePlayer(this.id);
            S_DELETE_USER sDeleteUser = new S_DELETE_USER();
            sDeleteUser.Send(this.Connection);
        }
    }
}