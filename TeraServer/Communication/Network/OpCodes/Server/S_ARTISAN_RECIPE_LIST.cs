using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_ARTISAN_RECIPE_LIST : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 0);
            WriteByte(writer, 0);
            WriteByte(writer, 1);
        }
    }
}