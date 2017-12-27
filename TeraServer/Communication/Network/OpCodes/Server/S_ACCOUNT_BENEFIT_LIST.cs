using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_ACCOUNT_BENEFIT_LIST : AServerPacket
    {
        private Account _account;

        public S_ACCOUNT_BENEFIT_LIST(Account account)
        {
            this._account = account;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, (short)this._account.accountPackages.Count);
            short next = (short) writer.BaseStream.Position;

            for (int i = 0; i < this._account.accountPackages.Count; i++)
            {
                writetoPos(writer, next, (short) writer.BaseStream.Position);
                WriteInt16(writer, (short)writer.BaseStream.Position);
                next = (short)writer.BaseStream.Position;
                WriteInt16(writer, 0);
                WriteInt32(writer, this._account.accountPackages[i]);
                WriteLong(writer, 1608927620);
                WriteInt32(writer, 40759);
                WriteLong(writer, 0);
                WriteByte(writer, 0);
            }
        }
    }
}