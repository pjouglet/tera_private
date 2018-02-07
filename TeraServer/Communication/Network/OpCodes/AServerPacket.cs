using System;
using System.IO;
using System.Text;
using TeraServer.Data.Interfaces;
using TeraServer.Data.Structures;
using TeraServer.Utils;

namespace TeraServer.Communication.Network.OpCodes
{
    public abstract class AServerPacket
    {
        protected byte[] Datas;
        protected object WriteLock = new object();

        public abstract void Write(BinaryWriter writer);

        protected void writeWorldId(BinaryWriter writer, Player player)
        {
            WriteLong(writer, player.UID);//todo : change with eid
        }
        
        protected void WriteSpawnId(BinaryWriter writer, Player player, bool login)
        {
            if (login)
            {
                writeWorldId(writer, player);
                WriteInt32(writer, 1096);//serverid
                WriteInt32(writer, player.playerId);
            }
            else
            {
                WriteInt32(writer, 1096);//serverid
                WriteInt32(writer, player.playerId);
                writeWorldId(writer, player);
            }
        }
        
        protected void WriteInt32(BinaryWriter writer, int val)
        {
            writer.Write(val);
        }

        protected void WriteInt16(BinaryWriter writer, short val)
        {
            writer.Write(val);
        }

        protected void WriteByte(BinaryWriter writer, byte val)
        {
            writer.Write(val);
        }

        protected void WriteDouble(BinaryWriter writer, double val)
        {
            writer.Write(val);
        }

        protected void WriteFloat(BinaryWriter writer, float val)
        {
            writer.Write(val);
        }

        protected void WriteLong(BinaryWriter writer, long val)
        {
            writer.Write(val);
        }

        protected void WriteString(BinaryWriter writer, String text)
        {
            if (text == null)
            {
                writer.Write((short) 0);
            }
            else
            {
                Encoding encoding = Encoding.Unicode;
                writer.Write(encoding.GetBytes(text));
                writer.Write((short) 0);
            }
        }

        protected void WriteHex(BinaryWriter writer, string hex)
        {
            Console.WriteLine(hex.HexSringToBytes().ToString());
            writer.Write(hex.HexSringToBytes());
        }

        protected void WriteBytes(BinaryWriter writer, byte[] data)
        {
            writer.Write(data);
        }

        protected void writetoPos(BinaryWriter writer, short position, short value)
        {
            writer.BaseStream.Seek(position, SeekOrigin.Begin);
            WriteInt16(writer, value);
            writer.BaseStream.Seek(0, SeekOrigin.End);
        }
        
        protected void writetoPos(BinaryWriter writer, short position, int value)
        {
            writer.BaseStream.Seek(position, SeekOrigin.Begin);
            WriteInt32(writer, value);
            writer.BaseStream.Seek(0, SeekOrigin.End);
        }
        
        protected void writetoPos(BinaryWriter writer, short position, string value)
        {
            writer.BaseStream.Seek(position, SeekOrigin.Begin);
            WriteString(writer, value);
            writer.BaseStream.Seek(0, SeekOrigin.End);
        }
        
        public void Send(IConnection state)
        {
            if (state == null || !state.IsValid)
                return;

            if (!OpCodes.ServerTypes.ContainsKey(GetType()))
            {
                Console.WriteLine("UNKNOW OpCode {0}", GetType().Name);
                return;
            }


            lock (WriteLock)
            {
                if (Datas == null)
                {
                    try
                    {
                        using (MemoryStream stream = new MemoryStream())
                        {
                            using (BinaryWriter writer = new BinaryWriter(stream, new UTF8Encoding()))
                            {
                                WriteInt16(writer, 0); //Reserved for length
                                WriteInt16(writer, OpCodes.ServerTypes[GetType()]);
                                Write(writer);
                            }

                            Datas = stream.ToArray();
                            BitConverter.GetBytes((short) Datas.Length).CopyTo(Datas, 0);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Can't write packet {0}", GetType().Name);
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
            }

            state.PushPacket(Datas);
        }

    }
}