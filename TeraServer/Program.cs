using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using TeraServer.Communication;

namespace TeraServer
{
    internal class Program
    {
        private static Server _server;
        public static void Main(string[] args)
        {
            Console.Title = "Tera Project";
            Console.CancelKeyPress += CancelEventHandler;
            _server = new Server();
            _server.MainLoop();
            _server.StopServer();
            Process.GetCurrentProcess().Kill();
        }

        protected static void CancelEventHandler(object sender, ConsoleCancelEventArgs args)
        {
             _server.StopServer();
        }
    }
}