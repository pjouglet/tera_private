﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Text;
using MySql.Data.MySqlClient;
using TeraServer.Data.Structures;
using TeraServer.Utils;

namespace TeraServer.Data.DAO
{
    public class PlayerDAO : BaseDAO
    {
        private MySqlConnection _mySqlConnection;
        
        public PlayerDAO(string str) : base(str)
        {
            this._mySqlConnection = new MySqlConnection(str);
            this._mySqlConnection.Open();
            
            Console.WriteLine("[DAO] : {0} players in the database.", this.LoadTotalPlayers());
        }

        private int LoadTotalPlayers()
        {
            string SQL = "SELECT COUNT(*) FROM `players`";
            MySqlCommand command = new MySqlCommand(SQL, this._mySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }

            reader.Close();

            return count;
        }

        public List<Player> LoadAccountPlayers(int accountId)
        {
            string SQL = "SELECT * FROM `players` WHERE `accountid` = ?id";
            MySqlCommand command = new MySqlCommand(SQL, this._mySqlConnection);
            command.Parameters.AddWithValue("?id", accountId);
            MySqlDataReader reader = command.ExecuteReader();
            
            List<Player> players = new List<Player>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Player player = new Player();
                    player.playerId = (int)reader.GetValue(reader.GetOrdinal("id"));
                    player.name = reader.GetValue(reader.GetOrdinal("name")).ToString();
                    player.posX = (double) reader.GetValue(reader.GetOrdinal("x"));
                    player.posY = (double) reader.GetValue(reader.GetOrdinal("y"));
                    player.posZ = (double) reader.GetValue(reader.GetOrdinal("z"));
                    player.heading = (int) reader.GetValue(reader.GetOrdinal("h"));
                    player.gender = (int) reader.GetValue(reader.GetOrdinal("gender"));
                    player.race = (int) reader.GetValue(reader.GetOrdinal("race"));
                    player.classId = (int) reader.GetValue(reader.GetOrdinal("class"));
                    player.xp = (int) reader.GetValue(reader.GetOrdinal("xp"));
                    player.restedXp = (int) reader.GetValue(reader.GetOrdinal("restedXp"));
                    player.areaId = (int) reader.GetValue(reader.GetOrdinal("area"));
                    player.continentId = (int) reader.GetValue(reader.GetOrdinal("continent"));
                    player.level = (int) reader.GetValue(reader.GetOrdinal("level"));
                    player.details1 = Funcs.HexToBytes(reader.GetValue(reader.GetOrdinal("details1")).ToString());
                    player.details2 = Funcs.HexToBytes(reader.GetValue(reader.GetOrdinal("details2")).ToString());
                    player.details3 = Funcs.HexToBytes(reader.GetValue(reader.GetOrdinal("details3")).ToString());
                    /*player.details1 = Encoding.ASCII.GetBytes(reader.GetValue(reader.GetOrdinal("details1")).ToString());
                    player.details1 = Encoding.ASCII.GetBytes(reader.GetValue(reader.GetOrdinal("details2")).ToString());
                    player.details1 = Encoding.ASCII.GetBytes(reader.GetValue(reader.GetOrdinal("details3")).ToString());*/
                    //player.lastOnline = (long) reader.GetValue(reader.GetOrdinal("lastOnline"));
                    //player.creationTime = (long) reader.GetValue(reader.GetOrdinal("creationTime"));
                    player.worldMapGuardId = (int) reader.GetValue(reader.GetOrdinal("worldMapGuardId"));
                    player.worldMapWorldId = (int) reader.GetValue(reader.GetOrdinal("worldMapWorldId"));
                    player.worldMapSectionId = (int) reader.GetValue(reader.GetOrdinal("worldMapSectionId"));
                    player.lobbyPosition = (int) reader.GetValue(reader.GetOrdinal("lobbyPosition"));
                    players.Add(player);
                    Console.WriteLine("OK");
                }
            }
            reader.Close();
            return players;
        }

        public bool UsernameValid(string username)
        {
            string SQL = "SELECT count(id) FROM `players` WHERE name = ?name";
            MySqlCommand command = new MySqlCommand(SQL, this._mySqlConnection);
            command.Parameters.AddWithValue("?name", username);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            return false;
        }
        public bool SaveNewPlayer(Player player, int accountId)
        {
            string SQL =
                "INSERT INTO `players`(`accountid`, `name`, `race`, `gender`, `class`, `details1`, `details2`, `details3`, `creationTime`, `lobbyPosition`) VALUES(?id, ?name, ?race, ?gender, ?class, ?details1, ?details2, ?details3, ?creationTime, ?lobbyPosition)";
            MySqlCommand command = new MySqlCommand(SQL, this._mySqlConnection);
            command.Parameters.AddWithValue("?id", accountId);
            command.Parameters.AddWithValue("?name", player.name);
            command.Parameters.AddWithValue("?race", player.race);
            command.Parameters.AddWithValue("?gender", player.gender);
            command.Parameters.AddWithValue("?class", player.classId);
            command.Parameters.AddWithValue("?details1", Funcs.BytesToHex(player.details1));
            command.Parameters.AddWithValue("?details2", Funcs.BytesToHex(player.details2));
            command.Parameters.AddWithValue("?details3", Funcs.BytesToHex(player.details3));
            command.Parameters.AddWithValue("?creationTime", Utils.Funcs.GetRoundedUtc());
            command.Parameters.AddWithValue("?lobbyPosition", 0);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when trying to save new character " + ex.Message);
            }
            return false;
        }
    }
}