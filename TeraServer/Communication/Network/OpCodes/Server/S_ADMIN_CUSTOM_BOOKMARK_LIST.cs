using System;
using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_ADMIN_CUSTOM_BOOKMARK_LIST : AServerPacket
    {
        private Player _player;
        public S_ADMIN_CUSTOM_BOOKMARK_LIST(Player player)
        {
            this._player = player;
        }
        public override void Write(BinaryWriter writer)
        {
            
            WriteInt16(writer, (short) _player.AdminBookmarks.Count);
            short next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            WriteInt16(writer, 0);
            for (int i = 0; i < _player.AdminBookmarks.Count; i++)
            {
                writetoPos(writer, next, (short) writer.BaseStream.Position);
                WriteInt16(writer, (short)writer.BaseStream.Position);
                next = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);
                short namepos = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);
                WriteInt16(writer, (short)_player.AdminBookmarks[i].continent);
                WriteFloat(writer, _player.AdminBookmarks[i].x);
                WriteFloat(writer, _player.AdminBookmarks[i].y);
                WriteFloat(writer, _player.AdminBookmarks[i].z);
                writetoPos(writer, namepos, (short) writer.BaseStream.Position);
                WriteString(writer, _player.AdminBookmarks[i].name);
            }
        }
    }
}