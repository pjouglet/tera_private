using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class S_NPC_MENU_SELECT : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 1);//type
        }
    }
}