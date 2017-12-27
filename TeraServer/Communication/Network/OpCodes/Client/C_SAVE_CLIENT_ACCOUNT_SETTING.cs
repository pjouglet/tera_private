using System;
using TeraServer.Data.DAO;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_SAVE_CLIENT_ACCOUNT_SETTING : AClientPacket
    {
        private byte[] data;
        public override void Read()
        {
            ReadC();
            int count = ReadC();
            this.data = ReadB(count);
        }

        public override void Process()
        {
            DAOManager.AccountDao.SaveAccountSettings(this.data, this.Connection.Account.AccountID);
        }
    }
}