using System;
using System.IO;
using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_STR_EVALUATE_LIST : AClientPacket
    {    
        private string username = String.Empty;
        private int type;
        public override void Read()
        {
            Reader.BaseStream.Seek(14, SeekOrigin.Current);
            this.type = ReadD();
            this.username = ReadS();
        }

        public override void Process()
        {
            S_STR_EVALUATE_LIST s_str_evaluate_list = new S_STR_EVALUATE_LIST(this.Connection, this.username, this.type);
            s_str_evaluate_list.Send(this.Connection);
        }
    }
}