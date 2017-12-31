using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SKILL_LEARN_RESULT : AServerPacket
    {
        public int skill;
        public int result;

        public S_SKILL_LEARN_RESULT(int skill, int result)
        {
            this.skill = skill;
            this.result = result;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, result);
            WriteInt16(writer, 0);
            WriteInt32(writer, skill);
            
        }
    }
}