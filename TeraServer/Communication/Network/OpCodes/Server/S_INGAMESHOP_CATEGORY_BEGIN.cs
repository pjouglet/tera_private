﻿using System.IO;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_INGAMESHOP_CATEGORY_BEGIN : AServerPacket
    {
        private byte category;

        public S_INGAMESHOP_CATEGORY_BEGIN(byte category)
        {
            this.category = category;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteByte(writer, this.category);
        }
    }
}