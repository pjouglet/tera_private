using System.IO;
using TeraServer.Data.DAO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_CHECK_USERNAME : AServerPacket
    {
        private string username;
        public S_CHECK_USERNAME(string username)
        {
            this.username = username;
        }
        
        public override void Write(BinaryWriter writer)
        {
            bool exist = DAOManager.PlayerDao.UsernameValid(this.username);
            if(exist)
                WriteByte(writer, 1);
            else
                WriteByte(writer, 0);
        }
    }
}