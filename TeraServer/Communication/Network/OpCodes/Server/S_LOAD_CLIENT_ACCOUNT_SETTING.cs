using System;
using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_LOAD_CLIENT_ACCOUNT_SETTING : AServerPacket
    {
        private Account _account;
        public S_LOAD_CLIENT_ACCOUNT_SETTING(Account account)
        {
            this._account = account;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 8);
            WriteInt16(writer, (short)this._account.accountSettings.Length);
            WriteBytes(writer, this._account.accountSettings);
        }
    }
}