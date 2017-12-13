using System;
using System.Collections.Generic;
using System.Linq;
using Hik.Communication.Scs.Communication.Messages;
using Hik.Communication.Scs.Server;
using TeraServer.Communication.Cryptography;
using TeraServer.Communication.Network.Protocol;
using TeraServer.Communication.Network.OpCodes;
using TeraServer.Data.Interfaces;
using TeraServer.Utils;
using System.Net.NetworkInformation;
using System.Threading;
using Hik.Communication.Scs.Communication;
using TeraServer.Configuration;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network
{
    public class Connection : IConnection
    {
        public static List<Connection> Connections = new List<Connection>();
        public static Thread sendThread = new Thread(SendThread);
        public byte[] buffer;
        private int state;
        private Session _session = new Session();
        private IScsServerClient Client;
        private List<byte[]> sendData = new List<byte[]>();
        private int sendDataSize;
        private object SendLock = new object();
        private Account _account;
        
        public Account Account
        {
            get { return _account; }
            set
            {
                if (value.Connection != null)
                    value.Connection.Close();
                _account = value;
                _account.Connection = this;
            }
        }

        public Connection(IScsServerClient client)
        {
            this.Client = client;
            this.Client.WireProtocol = new KeyProtocol();
            client.Disconnected += onClientDisconnected;
            client.MessageReceived += onClientMessageReceived;
            
            client.SendMessage(new KeyMessage{ Key = new byte[]{1, 0, 0, 0}});
            Connections.Add(this);
        }

        protected static void SendThread()
        {
            while (true)
            {
                for (int i = 0; i < Connections.Count; i++)
                {
                    try
                    {
                        if (!Connections[i].Send())
                            Connections.RemoveAt(i--);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error when trying to send packet : ", ex.Message);
                    }
                }
                Thread.Sleep(10);
            }
        }

        private void onClientDisconnected(object sender, EventArgs args)
        {
            
        }

        private bool Send()
        {
            GameMessage message;

            if (SendLock == null)
                return false;

            lock (SendLock)
            {
                if (sendData.Count == 0)
                    return Client.CommunicationState == CommunicationStates.Connected;

                message = new GameMessage {Data = new byte[sendDataSize]};
                
                int pointer = 0;
                for (int i = 0; i < sendData.Count; i++)
                {
                    Array.Copy(sendData[i], 0, message.Data, pointer, sendData[i].Length);
                    pointer += sendData[i].Length;
                }

                sendData.Clear();
                sendDataSize = 0;
            }

            try
            {
                if (Configuration.Config.DEBUG)
                {
                    string hexOpCode = BitConverter.GetBytes(message.OpCode).ToHex();
                    Console.WriteLine("Data: {0}{1}\n{2}", hexOpCode.Substring(2), hexOpCode.Substring(0,2), message.Data.FormatHex());
                }
                Client.SendMessage(message);
            }
            catch
            {
                
                return false;
            }

            return true;
        }
        
        private void onClientMessageReceived(object sender, MessageEventArgs args)
        {
            if (this.state == 0)
            {
                KeyMessage keyMessage = (KeyMessage) args.Message;
                System.Buffer.BlockCopy(keyMessage.Key, 0, _session.ClientKey1, 0, 128);
                this.Client.SendMessage(new KeyMessage{Key = _session.ServerKey1});
                state++;
                return;
            }

            if (this.state == 1)
            {

                KeyMessage keyMessage = (KeyMessage) args.Message;
                System.Buffer.BlockCopy(keyMessage.Key, 0, _session.ClientKey2, 0, 128);
                this.Client.SendMessage(new KeyMessage{Key = _session.ServerKey2});
                _session.Init();
                Client.WireProtocol = new GameProtocol(_session);
                state++;
                return;
            }

            GameMessage message = (GameMessage) args.Message;
            this.buffer = message.Data;
            string hexOpCode = BitConverter.GetBytes(message.OpCode).ToHex();
            if (Config.DEBUG)
            {
                Console.WriteLine("CLIENT 0x{0}{1}\r\n{2}", hexOpCode.Substring(2), hexOpCode.Substring(0, 2), message.Data.FormatHex());

            }
            if (OpCodes.OpCodes.ClientTypes.ContainsKey(message.OpCode))
            {
                ((AClientPacket) Activator.CreateInstance(OpCodes.OpCodes.ClientTypes[message.OpCode])).Process(this);
            }
            else
            {
                Console.WriteLine("Unknow OpCode 0x{0}{1} [{2}", hexOpCode.Substring(2), hexOpCode.Substring(0, 2), buffer.Length);
                Console.WriteLine("Data:\n{0}", buffer.FormatHex());
            }
        }
        
        public bool IsValid
        {
            get { return true; }
        }

        public void Close()
        {
            Client.Disconnect();
        }

        public void PushPacket(byte[] data)
        {
            sendData.Add(data);
            sendDataSize += data.Length;
        }

        public long Ping()
        {
            System.Net.NetworkInformation.Ping ping = new Ping();
            string ip = Client.RemoteEndPoint.ToString().Substring(6);
            ip = ip.Substring(0, ip.IndexOf(':'));

            PingReply pingReply = ping.Send(ip);

            return (pingReply != null) ? pingReply.RoundtripTime : 0;
        }
    }
}