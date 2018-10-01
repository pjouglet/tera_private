using System;
using TeraServer.Communication.Network.OpCodes.Server;
using TeraServer.Configuration;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_SKILL_LEARN_LIST : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            Config.DEBUG = true;
            S_SKILL_LEARN_LIST sSkillLearnList = new S_SKILL_LEARN_LIST(this.Connection.player);
            sSkillLearnList.Send(this.Connection);
            Config.DEBUG = false;
        }
    }
}