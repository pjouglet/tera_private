using System;
using System.Collections.Generic;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_CHECK_VERSION : AClientPacket
    {
        private Dictionary<int, int> versionList = new Dictionary<int, int>();
        public override void Read()
        {
            int count = ReadH();
            ReadH();
            for (int i = 0; i < count; i++)
            {
                ReadD();
                int index = ReadD();
                int value = ReadD();
                versionList.Add(index, value);
            }
        }

        public override void Process()
        {
            
        }
    }
}