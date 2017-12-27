using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_AVAILABLE_EVENT_MATCHING_LIST : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            //todo
            WriteInt32(writer, 0);//array1
            WriteInt32(writer, 0);//array2
            
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteInt32(writer, 0);
            WriteByte(writer,1);
            WriteByte(writer,1);
            WriteByte(writer,1);
            WriteInt32(writer, 11802);
            WriteInt32(writer, 184602);
            WriteInt32(writer, 2500);//vanguard credits
            WriteByte(writer, 0);
            WriteByte(writer, 0);
            WriteByte(writer, 1);
            WriteInt32(writer, 0);//limit all
            WriteInt32(writer, 0);//limit pvp
            WriteInt32(writer, 0);//limit dungeon
            WriteInt32(writer, 0);//limit solo
            WriteInt32(writer, 1);//level
        }
    }
}