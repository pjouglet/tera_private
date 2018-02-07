using TeraServer.Communication.Network.OpCodes.Server;
using TeraServer.Data.DAO;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_RETURN_TO_LOBBY : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_RETURN_TO_LOBBY sReturnToLobby = new S_RETURN_TO_LOBBY();
            sReturnToLobby.Send(this.Connection);
            
            S_DESPAWN_USER sDespawnUser = new S_DESPAWN_USER(this.Connection.player, 1);
            this.Connection.broadcastToOther(sDespawnUser);
            
            DAOManager.PlayerDao.savePlayer(this.Connection.player);
            this.Connection.player.Release();
            this.Connection.player = null;
        }
    }
}