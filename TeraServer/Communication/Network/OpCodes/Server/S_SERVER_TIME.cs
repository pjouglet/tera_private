using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SERVER_TIME : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteLong(writer, Utils.Funcs.GetRoundedUtc());
        }
    }
}