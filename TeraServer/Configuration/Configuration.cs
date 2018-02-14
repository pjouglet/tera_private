using System;
using System.Xml;

namespace TeraServer.Configuration
{
    public class Config
    {
        public static bool DEBUG = false;
        private static int fatigability_refresh = 0;
        private static int fatigability_update = 0;
        
        public static int FatigabilityUpdate
        {
            get => getFatigabilityUpdate();
        }

        public static int FatigabilityRefresh
        {
            get => getFatigabilityRefresh();
        }

        public static string getDatabaseHost()
        {
            string host = null;
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"config/database.xml");
                XmlNode node = document.SelectSingleNode("database/database_host");
                if (node != null)
                    host = node.InnerText;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unable to get the database host !");
            }
            return host;
        }
        
        public static string getDatabasePort()
        {
            string port = null;
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"config/database.xml");
                XmlNode node = document.SelectSingleNode("database/database_port");
                if (node != null)
                    port = node.InnerText;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unable to get the database port !");
            }
            return port;
        }
        
        public static string getDatabaseUser()
        {
            string user = null;
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"config/database.xml");
                XmlNode node = document.SelectSingleNode("database/database_user");
                if (node != null)
                    user = node.InnerText;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unable to get the database user !");
            }
            return user;
        }
        
        public static string getDatabasePassword()
        {
            string password = null;
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"config/database.xml");
                XmlNode node = document.SelectSingleNode("database/database_password");
                if (node != null)
                    password = node.InnerText;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unable to get the database password !");
            }
            return password;
        }
        
        public static string getDatabaseName()
        {
            string name = null;
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"config/database.xml");
                XmlNode node = document.SelectSingleNode("database/database_name");
                if (node != null)
                    name = node.InnerText;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unable to get the database name !");
            }
            return name;
        }
        
        public static string getServerIP(string defaultValue = "127.0.0.1")
        {
            string ip = defaultValue;
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"config/network.xml");
                XmlNode node = document.SelectSingleNode("network/server_ip");
                if (node != null)
                    ip = node.InnerText;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unable to get the server IP !");
            }
            return ip;
        }
        
        public static int getServerPort(int defaultValue = 11146)
        {
            int port = defaultValue;
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"config/network.xml");
                XmlNode node = document.SelectSingleNode("network/server_port");
                if (node != null)
                    port = Convert.ToInt32(node.InnerText);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unable to get the server port !");
            }
            return port;
        }
        
        public static int getServerMaxConnection(int defaultValue = 1000)
        {
            int max = defaultValue;
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"config/network.xml");
                XmlNode node = document.SelectSingleNode("network/server_max_connection");
                if (node != null)
                    max = Convert.ToInt32(node.InnerText);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unable to know how much player can be logged at the same time !");
            }
            return max;
        }
        
        public static int getMaxLevel(int defaultValue = 65)
        {
            int level = defaultValue;
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"config/server.xml");
                XmlNode node = document.SelectSingleNode("server/max_level");
                if (node != null)
                    level = Convert.ToInt32(node.InnerText);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unable to get the maximum level !");
            }
            return level;
        }
        
        public static int getFatigabilityRefresh()
        {
            if (Config.fatigability_refresh != 0)
                return Config.fatigability_refresh;
            
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"config/server.xml");
                XmlNode node = document.SelectSingleNode("server/fatigability_refresh");
                if (node != null)
                    Config.fatigability_refresh = Convert.ToInt32(node.InnerText);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unable to get the maximum level !");
            }
            return Config.fatigability_refresh;
        }
        
        public static int getFatigabilityUpdate()
        {
            if (Config.fatigability_update != 0)
                return Config.fatigability_update;
            
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"config/server.xml");
                XmlNode node = document.SelectSingleNode("server/fatigability_update");
                if (node != null)
                    Config.fatigability_update = Convert.ToInt32(node.InnerText);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unable to get the maximum level !");
            }
            return Config.fatigability_update;
        }
    }
}