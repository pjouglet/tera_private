using TeraServer.Data.DAO;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_CHANGE_USER_LOBBY_SLOT_ID : AClientPacket
    {
        private int playerId;
        private int position;
        public override void Read()
        {
            this.playerId = ReadD();
            this.position = ReadD();
        }

        public override void Process()
        {
            DAOManager.PlayerDao.ChangeLobbyPosition(this.playerId, this.position);
        }
    }
}