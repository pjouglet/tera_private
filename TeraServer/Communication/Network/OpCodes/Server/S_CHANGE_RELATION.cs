using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_CHANGE_RELATION : AServerPacket
    {
        private Player _player;
        private int relation;

        public S_CHANGE_RELATION(Player player, int relation)
        {
            this._player = player;
            this.relation = relation;
        }
        
        public override void Write(BinaryWriter writer)
        {
            writeWorldId(writer, this._player);
            WriteInt32(writer, relation);
        }
    }
}