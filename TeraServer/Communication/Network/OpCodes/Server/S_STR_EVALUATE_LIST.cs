using System;
using System.IO;
using TeraServer.Data.DAO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_STR_EVALUATE_LIST : AServerPacket
    {
        private Connection _connection;
        private string username = String.Empty;
        private int type;
        
        public S_STR_EVALUATE_LIST(Connection connection, string username, int type)
        {
            this._connection = connection;
            this.username = username;
            this.type = type;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, 1);
            WriteInt16(writer, 8);
            WriteInt16(writer, 8);
            WriteInt16(writer, 1);

            short name_pos = (short)writer.BaseStream.Position;
            WriteInt16(writer, 0);
            WriteInt32(writer, this.type);
            WriteInt32(writer, 0);

            writer.Seek(name_pos, SeekOrigin.Begin);
            WriteInt16(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);
            WriteString(writer, this.username);
        }
    }
}