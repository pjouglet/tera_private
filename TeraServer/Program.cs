using System;
using System.Collections.Generic;
using TeraServer.Communication;

namespace TeraServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Tera Project";
            Server server = new Server();
            server.MainLoop();
            server.StopServer();
        }
    }
}