using TeraServer.Data.DAO;
using TeraServer.Data.Structures;

namespace TeraServer.Data.Interfaces
{
    public interface IConnection
    {
        Account Account { get; set; }
        //todo add player
        bool IsValid { get; }

        void Close();
        void PushPacket(byte[] data);
        long Ping();
    }
}