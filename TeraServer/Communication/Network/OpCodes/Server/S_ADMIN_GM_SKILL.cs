using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_ADMIN_GM_SKILL : AServerPacket
    {
        public int skill;
        public byte enabled;

        public S_ADMIN_GM_SKILL(int skill, byte enabled)
        {
            this.skill = skill;
            this.enabled = enabled;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, this.skill);
            WriteByte(writer, this.enabled);
        }
    }
}