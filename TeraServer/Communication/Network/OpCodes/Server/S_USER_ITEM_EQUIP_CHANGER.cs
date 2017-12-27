using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_USER_ITEM_EQUIP_CHANGER : AServerPacket
    {
        private int id;
        public S_USER_ITEM_EQUIP_CHANGER(int playerId)
        {
            this.id = playerId;
        }
        
        public override void Write(BinaryWriter writer)
        {
            int[] data = new int[] {1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 19, 20};
            WriteInt16(writer, (short)data.Length);
            short next = (short) writer.BaseStream.Position;
            WriteInt16(writer, 0);
            WriteLong(writer, this.id);

            for (int i = 0; i < data.Length; i++)
            {
                writetoPos(writer, next, (short) writer.BaseStream.Position);
                WriteInt16(writer, (short) writer.BaseStream.Position);
                next = (short) writer.BaseStream.Position;
                WriteInt16(writer, 0);
                WriteLong(writer, data[i]);
            }
        }
    }
}