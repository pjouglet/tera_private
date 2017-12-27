using TeraServer.Data.DAO;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_SAVE_CLIENT_USER_SETTING : AClientPacket
    {
        private byte[] data;
        public override void Read()
        {
            ReadH();
            int count = ReadH();
            this.data = ReadB(count);
        }

        public override void Process()
        {
            DAOManager.PlayerDao.savePlayerAccountSettings(this.Connection.player, this.data);
        }
    }
}