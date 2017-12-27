using TeraServer.Communication.Network.OpCodes.Server;
using TeraServer.Data.DAO;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_EXIT : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_EXIT sExit = new S_EXIT();
            sExit.Send(this.Connection);
            DAOManager.PlayerDao.savePlayer(this.Connection.player);
            Connection.Connections.Remove(this.Connection);
        }
    }
}