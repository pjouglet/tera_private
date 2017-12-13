using System;
using System.Text.RegularExpressions;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.Scs.Server;
using TeraServer.Communication.Network;

namespace TeraServer.Communication
{
    public class TCPServer
    {
        protected string BindAddress;
        protected int BinPort;
        protected int MaxConnection;

        public IScsServer server;

        public TCPServer(string bindAddress, int binPort, int maxConnection)
        {
            this.BindAddress = bindAddress;
            this.BinPort = binPort;
            this.MaxConnection = maxConnection;
        }

        public void BeginListening()
        {
            this.server = ScsServerFactory.CreateServer(new ScsTcpEndPoint(this.BindAddress, this.BinPort));
            this.server.Start();

            this.server.ClientConnected += onClientConnected;
            this.server.ClientDisconnected += onClientDisconnected;
        }

        public void ShutdownServer()
        {
            this.server.Stop();
            Server.serverOn = false;
        }

        public void onClientConnected(object sender, ServerClientEventArgs args)
        {
            string userIP = Regex.Match(args.Client.RemoteEndPoint.ToString(), "([0-9]+).([0-9]+).([0-9]+).([0-9]+)")
                .Value;
            Console.WriteLine("Client connected on IP : " + userIP);
            
            new Connection(args.Client);
        }

        public void onClientDisconnected(object sender, ServerClientEventArgs args)
        {
            Console.WriteLine("Client disconnected");
        }
    }
}