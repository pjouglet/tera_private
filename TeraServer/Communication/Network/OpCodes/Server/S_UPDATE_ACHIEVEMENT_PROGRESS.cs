using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_UPDATE_ACHIEVEMENT_PROGRESS : AServerPacket
    {
        private Player _player;

        public S_UPDATE_ACHIEVEMENT_PROGRESS(Player player)
        {
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt16(writer, (short)this._player.Achievements.progress.Count);
            short next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            for (int i = 0; i < this._player.Achievements.progress.Count; i++)
            {
                writetoPos(writer, next, (short) writer.BaseStream.Position);
                next = (short) writer.BaseStream.Position;
                WriteInt16(writer,(short) this._player.Achievements.progress[i].requirements.Count);

                short requirement = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);

                for (int j = 0; j < this._player.Achievements.progress[i].requirements.Count; j++)
                {
                    writetoPos(writer, requirement, (short) writer.BaseStream.Position);
                    requirement = (short) writer.BaseStream.Position;
                    WriteInt16(writer, 0);
                    WriteInt32(writer, j);
                    WriteInt32(writer, 1);
                    WriteLong(writer, 0);
                }
            }
        }
    }
}