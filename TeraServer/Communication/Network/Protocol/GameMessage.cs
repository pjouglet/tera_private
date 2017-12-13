using Hik.Communication.Scs.Communication.Messages;

namespace TeraServer.Communication.Network.Protocol
{
    public class GameMessage : ScsMessage
    {
        public short OpCode;

        public byte[] Data;
    }
}