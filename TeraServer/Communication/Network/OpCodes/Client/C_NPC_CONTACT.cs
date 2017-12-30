using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_NPC_CONTACT : AClientPacket
    {
        private long npc_id;
        public override void Read()
        {
            this.npc_id = ReadQ();
        }

        public override void Process()
        {
            S_NPC_MENU_SELECT sNpcMenuSelect = new S_NPC_MENU_SELECT();
            sNpcMenuSelect.Send(this.Connection);
            S_DIALOG sDialog = new S_DIALOG(this.npc_id);
            sDialog.Send(this.Connection);
        }
    }
}