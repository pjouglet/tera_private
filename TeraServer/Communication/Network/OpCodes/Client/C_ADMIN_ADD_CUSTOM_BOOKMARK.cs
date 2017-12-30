using System;
using TeraServer.Data.DAO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class C_ADMIN_ADD_CUSTOM_BOOKMARK : AClientPacket
    {
        private int continent;
        private float x;
        private float y;
        private float z;
        private string name;
        public override void Read()
        {
            ReadD();
            ReadH();
            this.continent = ReadD();
            this.x = ReadF();
            this.y = ReadF();
            this.z = ReadF();
            this.name = ReadS();
        }

        public override void Process()
        {
            if (this.Connection.player.GM == 1)
            {
                DAOManager.PlayerDao.saveAdminBookMark(continent, x, y, z, name, this.Connection.player);
            }
        }
    }
}