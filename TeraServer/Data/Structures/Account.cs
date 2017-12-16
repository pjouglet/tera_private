using System;
using System.Collections.Generic;
using TeraServer.Data.Interfaces;

namespace TeraServer.Data.Structures
{
    public class Account
    {
        public IConnection Connection;

        public int AccountID;
        public string AccountName = string.Empty;
        public string Ticket = string.Empty;
        public string Email = string.Empty;
        public string IP = String.Empty;
        public int vipLevel;
        public int vipCredits;
        
        public List<Player> Players = new List<Player>();
        public List<int> accountPackages = new List<int>();
        
        public bool isOnline
        {
            get { return Connection != null; }
        }

        public void Release()
        {
            //todo release each players,
        }
    }
}