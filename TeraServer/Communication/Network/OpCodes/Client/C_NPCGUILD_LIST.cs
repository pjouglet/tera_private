using System;
using TeraServer.Communication.Network.OpCodes.Server;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_NPCGUILD_LIST : AClientPacket
    {
        private string name;
        
        public override void Read()
        {
            ReadH();
            this.name = ReadS();
        }

        public override void Process()
        {
            if (this.name == this.Connection.player.name)
            {
                S_NPCGUILD_LIST sNpcguildList = new S_NPCGUILD_LIST(this.Connection.player);
                sNpcguildList.Send(this.Connection);
            }
            else
            {
                Connection connection = Connection.Connections.Find(x => x.player.name == this.name);
                if (connection != null)
                {
                    S_NPCGUILD_LIST sNpcguildList = new S_NPCGUILD_LIST(connection.player);
                    sNpcguildList.Send(this.Connection);
                }
                else
                {
                    //todo: send error message "user not connected"
                }
            }
           
        }
    }
}