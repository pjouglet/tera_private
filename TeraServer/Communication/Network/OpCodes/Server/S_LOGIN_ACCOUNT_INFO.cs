using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_LOGIN_ACCOUNT_INFO : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 14);
            WriteDouble(writer, 3656625);
            WriteString(writer, "TERA-PROJECT");
            
        }
    }
}