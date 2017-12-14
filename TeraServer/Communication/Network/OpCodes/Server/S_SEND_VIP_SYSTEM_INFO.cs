using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SEND_VIP_SYSTEM_INFO : AServerPacket
    {
        private Account _account;
        public S_SEND_VIP_SYSTEM_INFO(Account account)
        {
            this._account = account;
        }
        public override void Write(BinaryWriter writer)
        {
            short next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            WriteByte(writer, 1);
            WriteInt32(writer, this._account.vipLevel);//tier
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteDouble(writer, this._account.vipCredits);
            WriteByte(writer, 1);
            WriteDouble(writer, 1608927620);
            WriteDouble(writer, 1608927620);
            WriteByte(writer, 1);
            writetoPos(writer, next, (short)writer.BaseStream.Position);
            WriteInt16(writer, 0);
        }
    }
}