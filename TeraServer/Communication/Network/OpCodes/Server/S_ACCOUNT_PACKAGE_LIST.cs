using System.Collections.Generic;
using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_ACCOUNT_PACKAGE_LIST : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            List<int> package = new List<int>();
            package.Add(433);
            package.Add(434);
            
            WriteInt16(writer,(short) package.Count);
            short next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);


            for (int i = 0; i < package.Count; i++)
            {
                writetoPos(writer, next,(short) writer.BaseStream.Position);
                WriteInt16(writer, (short) writer.BaseStream.Position);
                next = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);
                WriteInt32(writer, package[i]);
                WriteDouble(writer, 1608927620);
            }            
        }
    }
}