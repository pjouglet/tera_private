using Hik.Communication.Scs.Communication.Messages;

namespace TeraServer.Communication.Network.Protocol
{
    public class KeyMessage : ScsMessage
    {
        public byte[] Key;
    }
}