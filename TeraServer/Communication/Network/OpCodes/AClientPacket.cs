using System;
using System.IO;
using System.Text;

namespace TeraServer.Communication.Network.OpCodes
{
    public abstract class AClientPacket
    {
        public BinaryReader Reader;
        public Connection Connection;

        public void Process(Connection connection)
        {
            Connection = connection;

            using (Reader = new BinaryReader(new MemoryStream(connection.buffer)))
            {
                Read();
            }

            try
            {
                Process();
            }
            catch (Exception ex)
            {
                
            }
        }

        public abstract void Read();

        public abstract void Process();

        protected int ReadD()
        {
            try
            {
                return Reader.ReadInt32();
            }
            catch (Exception)
            {
                
            }
            return 0;
        }

        protected int ReadC()
        {
            try
            {
                return Reader.ReadByte() & 0xFF;
            }
            catch (Exception)
            {
                
            }
            return 0;
        }

        protected int ReadH()
        {
            try
            {
                return Reader.ReadInt16() & 0xFFFF;
            }
            catch (Exception)
            {
                
            }
            return 0;
        }

        protected double ReadDf()
        {
            try
            {
                return Reader.ReadDouble();
            }
            catch (Exception)
            {
                
            }
            return 0;
        }

        protected float ReadF()
        {
            try
            {
                return Reader.ReadSingle();
            }
            catch (Exception)
            {
                
            }
            return 0;
        }

        protected long ReadQ()
        {
            try
            {
                return Reader.ReadInt64();
            }
            catch (Exception)
            {
                
            }
            return 0;
        }

        protected String ReadS()
        {
            Encoding encoding = Encoding.Unicode;
            String result = "";
            try
            {
                short ch;
                while ((ch = Reader.ReadInt16()) != 0)
                    result += encoding.GetString(BitConverter.GetBytes(ch));
            }
            catch (Exception e)
            {
                 Console.WriteLine(e.Message);   
            }
            return result;
        }

        protected byte[] ReadB(int length)
        {
            byte[] result = new byte[length];
            try
            {
                Reader.Read(result, 0, length);
            }
            catch (Exception)
            {
                
            }
            return result;
        }
    }
}