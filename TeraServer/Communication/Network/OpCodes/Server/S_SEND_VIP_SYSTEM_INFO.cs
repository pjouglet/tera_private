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
            WriteLong(writer, this._account.vipExp);
            WriteInt32(writer, this._account.vipCredits);
            WriteInt32(writer, 0);
            WriteByte(writer, 1);
            WriteDouble(writer, Utils.Funcs.GetCurrentMilliseconds());
            WriteDouble(writer, Utils.Funcs.GetCurrentMilliseconds());
            WriteByte(writer, 1);
            writetoPos(writer, next, (short)writer.BaseStream.Position);
            WriteInt16(writer, 0);
        }
    }
}