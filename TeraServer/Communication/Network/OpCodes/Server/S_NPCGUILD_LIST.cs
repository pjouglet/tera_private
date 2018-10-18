using System.IO;
using TeraServer.Data.Structures;
using TeraServer.Data.Structures.Enums;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_NPCGUILD_LIST : AServerPacket
    {
        private Player _player;
        public S_NPCGUILD_LIST(Player player)
        {
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, (short)NPCGuilds.NpcGuildsList.Count);
            short next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            
            writeWorldId(writer, this._player);
            
            foreach (NPCGuilds npcGuilds in this._player.npcGuild)
            {
                writetoPos(writer, next, (short)writer.BaseStream.Position);
                WriteInt16(writer, (short) writer.BaseStream.Position);
                next = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);
                
                WriteInt32(writer, npcGuilds.region);
                WriteInt32(writer, npcGuilds.faction);
                WriteInt32(writer, (int) npcGuilds.PlayerReputation);
                WriteInt32(writer, npcGuilds.reputation);
                WriteInt32(writer, npcGuilds.credits);
            }
        }
    }
}