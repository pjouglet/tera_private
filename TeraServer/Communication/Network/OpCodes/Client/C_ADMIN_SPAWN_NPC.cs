using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_ADMIN_SPAWN_NPC : AClientPacket
    {
        private int huntingZone;
        private int templateid;
        private int count;
        private int val4;
        public override void Read()
        {
            this.huntingZone = ReadD();
            this.templateid = ReadD();
            this.count = ReadD();
            ReadH();
            this.val4 = ReadD();
        }

        public override void Process()
        {
            for (int i = 0; i < count; i++)
            {
                S_SPAWN_NPC spawnNpc = new S_SPAWN_NPC(this.Connection.player, huntingZone, templateid, count, val4);
                spawnNpc.Send(this.Connection);
            }
            
        }
    }
}