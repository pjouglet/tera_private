using System;
using System.IO;
using TeraServer.Data.DAO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_HARDWARE_INFO : AClientPacket
    {
        private string os;
        private string cpu;
        private string gpu;
        private int memory;
   
        public override void Read()
        {
            short osOffset = (short)ReadH();
            short cpuOffset = (short)ReadH();
            short gpuOffset = (short)ReadH();
            this.memory = ReadD();
            Reader.BaseStream.Seek(osOffset-4, SeekOrigin.Begin);
            this.os = ReadS();
            this.cpu = ReadS();
            this.gpu = ReadS();

        }

        public override void Process()
        {
            DAOManager.AccountDao.SaveHarwareInfo(this.os, this.cpu, this.gpu, this.memory, this.Connection.Account);
        }
    }
}