using TeraServer.Communication.Network.OpCodes.Server;
using TeraServer.Data.DAO;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_SKILL_LEARN_REQUEST : AClientPacket
    {
        private int skill;
        public override void Read()
        {
            ReadD();
            this.skill = ReadD();
        }

        public override void Process()
        {
            bool result = this.Connection.player.learnSkill(this.skill);
            if(result)
                DAOManager.PlayerDao.savePlayerSkills(this.Connection.player);
            S_SKILL_LEARN_RESULT sSkillLearnResult = new S_SKILL_LEARN_RESULT(skill, ((result) ? 1 : 0));
            sSkillLearnResult.Send(this.Connection);
            
            S_SKILL_LIST skillList = new S_SKILL_LIST(this.Connection.player);
            skillList.Send(this.Connection);
            //todo update inventory, send crest, send stats
        }
    }
}