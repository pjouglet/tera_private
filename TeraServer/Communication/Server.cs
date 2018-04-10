﻿using System;
using System.Threading;
using TeraServer.Communication.Network;
using TeraServer.Communication.Network.OpCodes;
using TeraServer.Configuration;
using TeraServer.Data.DAO;
using TeraServer.Data.Structures;
using TeraServer.Data.Structures.Templates;

namespace TeraServer.Communication
{
    public class Server
    {
        private TCPServer TcpServer;
        public static bool serverOn;

        public Server()
        {
            try
            {
                Console.WriteLine("Starting Server...");
                this.TcpServer = new TCPServer("*", Config.getServerPort(), Config.getServerMaxConnection());

                Connection.SendAllThread.Start();
                
                Levels.LoadLevels();
                
                Console.WriteLine("Loading skills...");
                Skill_Template.LoadSkills();
                Console.WriteLine("Loaded " + Skill_Template.SkillTemplates.Count + " skills");
                
                Console.WriteLine("Loading templates...");
                Class_Template.LoadTemplates();
                Race_Template.LoadTemplates();
                Console.WriteLine("Loaded " + (Class_Template.ClassTemplates.Count + Race_Template.RaceTemplates.Count) + " templates");
                
                Console.WriteLine("Loading Achievements...");
                Achievements.LoadAchievementsFromFile();
                Console.WriteLine("Loaded " + Achievements.achievementList.Count + " achievements");
                
                Console.WriteLine("Loading OpCodes...");
                OpCodes.Init();
                Console.WriteLine("Loaded "+ (OpCodes.ClientTypes.Count + OpCodes.ServerTypes.Count)+ " OpCodes" );
                
                DAOManager.Initialise("SERVER=" + Config.getDatabaseHost() + ";DATABASE=" + Config.getDatabaseName() + ";UID=" + Config.getDatabaseUser() + ";PASSWORD=" + Config.getDatabasePassword() + ";PORT=" + Config.getDatabasePort() + ";charset=utf8");
                
                Console.WriteLine("Loading TCP...");
                this.TcpServer.BeginListening();
                
                Connection.sendThread.Start();
                Console.WriteLine("Server Started !");
                Server.serverOn = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Can't start server : ", exception.Message);
                return;
            }
        }

        public void MainLoop()
        {
            while (Server.serverOn)
            {
                try
                {
                    
                }
                catch (Exception exception)
                {
                    Console.WriteLine("MainLoop Exception : ", exception.Message);
                }
                Thread.Sleep(10);
            }
        }

        public void StopServer()
        {
            this.TcpServer.ShutdownServer();
            this.SaveAllPlayer();
        }

        private void SaveAllPlayer()
        {
            for (int i = 0; i < Connection.Connections.Count; i++)
            {
                try
                {
                    if(Connection.Connections[i].player != null)
                        DAOManager.PlayerDao.savePlayer(Connection.Connections[i].player);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SaveAllPlayer Error : " + ex.Message);
                }
            }
        }
    }
}