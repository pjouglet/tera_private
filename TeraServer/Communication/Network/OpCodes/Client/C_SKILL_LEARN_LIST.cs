using System;
using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_SKILL_LEARN_LIST : AClientPacket
    {
        public override void Read()
        {
            Console.WriteLine("received");
        }

        public override void Process()
        {
            S_SKILL_LEARN_LIST sSkillLearnList = new S_SKILL_LEARN_LIST(this.Connection.player);
            sSkillLearnList.Send(this.Connection);
        }
    }
}