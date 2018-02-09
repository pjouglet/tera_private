﻿using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_PONG : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_PING sPing = new S_PING();
            sPing.Send(this.Connection);
        }
    }
}