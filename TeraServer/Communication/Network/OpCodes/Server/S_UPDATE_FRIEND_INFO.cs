﻿using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_UPDATE_FRIEND_INFO : AServerPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteInt32(writer, 0);
        }
    }
}