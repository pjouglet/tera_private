using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using MySql.Data.MySqlClient;
using TeraServer.Communication.Network.OpCodes.Server;
using TeraServer.Data.Structures;
using TeraServer.Data.Structures.Enums;
using TeraServer.Data.Structures.Templates;
using TeraServer.Utils;

namespace TeraServer.Data.DAO
{
    public class PlayerDAO : BaseDAO
    {
        private MySqlConnection _mySqlConnection;
        public static Thread UpdatePlayerThread = new Thread(upDatePlayersThread);
        
        public static void upDatePlayersThread()
        {
            while (true)
            {
                for (int i = 0; i < Communication.Network.Connection.Connections.Count; i++)
                {
                    if (Communication.Network.Connection.Connections[i].player != null)
                    {
                        Player player = Communication.Network.Connection.Connections[i].player;
                        if (player.playerStats.hp > 0)
                        {
                            player.updateStats();
                            S_PLAYER_STAT_UPDATE sPlayerStatUpdate = new S_PLAYER_STAT_UPDATE(player);
                            sPlayerStatUpdate.Send(Communication.Network.Connection.Connections[i]);
                        }
                    }
                }
                Thread.Sleep(3000);
            }
        }
        
        public PlayerDAO(string str) : base(str)
        {
            this._mySqlConnection = new MySqlConnection(str);
            this._mySqlConnection.Open();
            
            Console.WriteLine("[DAO] : {0} players in the database.", this.LoadTotalPlayers());
        }

        private int LoadTotalPlayers()
        {
            string SQL = "SELECT COUNT(*) FROM `players` WHERE `deleted` = 0";
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
            string SQL = "SELECT * FROM `players` WHERE `accountid` = ?id AND `deleted` = 0";
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
                    player.posX = (float) reader.GetValue(reader.GetOrdinal("x"));
                    player.posY = (float) reader.GetValue(reader.GetOrdinal("y"));
                    player.posZ = (float) reader.GetValue(reader.GetOrdinal("z"));
                    player.heading = (int) reader.GetValue(reader.GetOrdinal("h"));
                    player.gender = (Player_Gender) reader.GetValue(reader.GetOrdinal("gender"));
                    player.race = (Player_Race) reader.GetValue(reader.GetOrdinal("race"));
                    player.classId = (Player_Class) reader.GetValue(reader.GetOrdinal("class"));
                    player.xp = (int) reader.GetValue(reader.GetOrdinal("xp"));
                    player.restedXp = (int) reader.GetValue(reader.GetOrdinal("restedXp"));
                    player.areaId = (int) reader.GetValue(reader.GetOrdinal("area"));
                    player.continentId = (int) reader.GetValue(reader.GetOrdinal("continent"));
                    player.level = (int) reader.GetValue(reader.GetOrdinal("level"));
                    player.title = (int) reader.GetValue(reader.GetOrdinal("title"));
                    player.details1 = Funcs.HexToBytes(reader.GetValue(reader.GetOrdinal("details1")).ToString());
                    player.details2 = Funcs.HexToBytes(reader.GetValue(reader.GetOrdinal("details2")).ToString());
                    player.details3 = Funcs.HexToBytes(reader.GetValue(reader.GetOrdinal("details3")).ToString());
                    //player.lastOnline = (long) reader.GetValue(reader.GetOrdinal("lastOnline"));
                    //player.creationTime = (long) reader.GetValue(reader.GetOrdinal("creationTime"));
                    player.worldMapGuardId = (int) reader.GetValue(reader.GetOrdinal("worldMapGuardId"));
                    player.worldMapWorldId = (int) reader.GetValue(reader.GetOrdinal("worldMapWorldId"));
                    player.worldMapSectionId = (int) reader.GetValue(reader.GetOrdinal("worldMapSectionId"));
                    player.lobbyPosition = (int) reader.GetValue(reader.GetOrdinal("lobbyPosition"));
                    player.GM = (int) reader.GetValue(reader.GetOrdinal("gm"));
                    player.accountSettings = Funcs.HexToBytes(reader.GetValue(reader.GetOrdinal("accountSettings")).ToString());
                    player.Achievements = new Achievements();
                    player.playerStats = new Stats();
                    players.Add(player);

                }
            }
            reader.Close();
            for (int i = 0; i < players.Count; i++)
                loadPlayerStats(players[i]);
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
            command.Parameters.AddWithValue("?race", (int)player.race);
            command.Parameters.AddWithValue("?gender", (int)player.gender);
            command.Parameters.AddWithValue("?class", (int)player.classId);
            command.Parameters.AddWithValue("?details1", Funcs.BytesToHex(player.details1));
            command.Parameters.AddWithValue("?details2", Funcs.BytesToHex(player.details2));
            command.Parameters.AddWithValue("?details3", Funcs.BytesToHex(player.details3));
            command.Parameters.AddWithValue("?creationTime", Utils.Funcs.GetRoundedUtc());
            command.Parameters.AddWithValue("?lobbyPosition", 0);
            try
            {
                player.playerId = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when trying to save new character " + ex.Message);
            }

            SQL = "INSERT INTO `player_stats`(`playerid`, `hp`, `mp`, `stamina`) VALUES(?id, ?hp, ?mp, ?stamina)";
            command = new MySqlCommand(SQL, this._mySqlConnection);
            command.Parameters.AddWithValue("?id", player.playerId);
            command.Parameters.AddWithValue("?hp", player.playerStats.hp);
            command.Parameters.AddWithValue("?mp", player.playerStats.mp);
            command.Parameters.AddWithValue("?stamina", player.playerStats.stamina);
            
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when trying to save stats of new character " + ex.Message);
            }
            return false;
        }

        public void DeletePlayer(int playerId)
        {
            string SQL = "UPDATE `players` SET `deleted` = 1 WHERE id = ?id";
            MySqlCommand command = new MySqlCommand(SQL, this._mySqlConnection);
            command.Parameters.AddWithValue("?id", playerId);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error when trying to deleted character : " + ex.Message);
            }
        }

        public void ChangeLobbyPosition(int playerId, int position)
        {
            string SQL = "UPDATE `players` SET `lobbyPosition` = ?position WHERE `id` = ?id";
            MySqlCommand command = new MySqlCommand(SQL, this._mySqlConnection);
            command.Parameters.AddWithValue("?position", position);
            command.Parameters.AddWithValue("?id", playerId);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when trying to change lobbyPosition :" + ex.Message);
            }
        }

        public void savePlayer(Player player)
        {
            string SQL = "UPDATE `players` SET `x` = ?x, `y` = ?y, `z` = ?z, `xp` = ?xp, `restedXp` = ?restedxp, `area` = ?area, `continent` = ?continent, `level` = ?level, `title` = ?title, `lastOnline` = ?lastOnline, `worldMapGuardId` = ?guardId, `worldMapWorldId` = ?worldId, `worldMapSectionId` = ?sectionId WHERE `id` = ?id";
            MySqlCommand command = new MySqlCommand(SQL, this._mySqlConnection);
            command.Parameters.AddWithValue("?x", player.posX);
            command.Parameters.AddWithValue("?y", player.posY);
            command.Parameters.AddWithValue("?z", player.posZ);
            command.Parameters.AddWithValue("?xp", player.xp);
            command.Parameters.AddWithValue("?restedxp", player.restedXp);
            command.Parameters.AddWithValue("?area", player.areaId);
            command.Parameters.AddWithValue("?continent", player.continentId);
            command.Parameters.AddWithValue("?level", player.level);
            command.Parameters.AddWithValue("?title", player.title);
            command.Parameters.AddWithValue("?lastOnline", (int)Utils.Funcs.GetCurrentMilliseconds());
            command.Parameters.AddWithValue("?guardId", player.worldMapGuardId);
            command.Parameters.AddWithValue("?worldId", player.worldMapWorldId);
            command.Parameters.AddWithValue("?sectionId", player.worldMapSectionId);
            command.Parameters.AddWithValue("?id", player.playerId);
            try
            {
                command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when trying to save player :" + ex.Message);
            }
            savePlayerStats(player);
            
        }

        public void savePlayerAccountSettings(Player player, byte[] data)
        {
            string SQL = "UPDATE `players` SET `accountSettings` = ?settings WHERE `id` = ?id";
            MySqlCommand command = new MySqlCommand(SQL, this._mySqlConnection);
            command.Parameters.AddWithValue("?settings", Funcs.BytesToHex(data));
            command.Parameters.AddWithValue("?id", player.playerId);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error when trying to save user settings " + e.Message);
                throw;
            }
        }

        public void saveAdminBookMark(int continent, float x, float y, float z, string name, Player player)
        {
            string SQL =
                "INSERT INTO `admin_bookmark`(`playerid`, `continent`, `x`, `y`, `z`, `name`) VALUES(?id, ?continent, ?x, ?y, ?z, ?name)";
            MySqlCommand command = new MySqlCommand(SQL, this._mySqlConnection);
            command.Parameters.AddWithValue("?id", player.playerId);
            command.Parameters.AddWithValue("?continent", continent);
            command.Parameters.AddWithValue("?x", x);
            command.Parameters.AddWithValue("?y", y);
            command.Parameters.AddWithValue("?z", z);
            command.Parameters.AddWithValue("?name", name);

            try
            {
                Console.WriteLine("sgsqfg1");
                command.ExecuteNonQuery();
                Console.WriteLine("sgsqfg2");

            }
            catch (SqlException e)
            {
                Console.WriteLine("Error when trying to save admin bookmark " + e.Message);
            }
        }

        public void loadAdminBookmarks(Player player)
        {
            string SQL = "SELECT * FROM `admin_bookmark` WHERE `playerid` = ?id";
            MySqlCommand command = new MySqlCommand(SQL, this._mySqlConnection);
            command.Parameters.AddWithValue("?id", player.playerId);

            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    bookmark bookmark = new bookmark();
                    bookmark.continent = (int) reader.GetValue(reader.GetOrdinal("continent"));
                    bookmark.x = (float) reader.GetValue(reader.GetOrdinal("x"));
                    bookmark.y = (float) reader.GetValue(reader.GetOrdinal("y"));
                    bookmark.z = (float) reader.GetValue(reader.GetOrdinal("z"));
                    bookmark.name = reader.GetValue(reader.GetOrdinal("name")).ToString();
                    player.AdminBookmarks.Add(bookmark);
                }
                
            }
            reader.Close();
        }

        private void loadPlayerStats(Player player)
        {
            Console.WriteLine("ID : "+ player.playerId);
                string SQL = "SELECT * FROM player_stats WHERE `playerid` = ?id";
            MySqlCommand command = new MySqlCommand(SQL, this._mySqlConnection);
            command.Parameters.AddWithValue("?id", player.playerId);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    player.playerStats.hp = (int)reader.GetValue(reader.GetOrdinal("hp"));
                    player.playerStats.mp = (int)reader.GetValue(reader.GetOrdinal("mp"));
                    player.playerStats.stamina = (int)reader.GetValue(reader.GetOrdinal("stamina"));
                        
                    Class_Template template = Class_Template.ClassTemplates[Convert.ToInt32(player.classId)];
                    
                    player.playerStats.maxHp = template.maxHp;
                    player.playerStats.maxMp = template.maxMp;
                    player.playerStats.walkSpeed = template.walkSpeed;
                    player.playerStats.movementSpeed = template.movementSpeed;
                    player.playerStats.critRate = template.critRate;
                    player.playerStats.critResist = template.critResist;
                    player.playerStats.critPower = template.critPower;
                    player.playerStats.staminaMax = template.maxStamina;
                    
                    //stun rate
                    //periodic rate
                    //weakening rate
                    player.playerStats.resistWeakening = template.weakeningResist;
                    player.playerStats.resistPeriodic = template.periodicResist;
                    player.playerStats.resistStun = template.stunResist;
                }
            }
            reader.Close();
            Console.WriteLine("done");
        }

        private void savePlayerStats(Player player)
        {
            string SQL = "UPDATE `player_stats` SET `hp` = ?hp, `mp` = ?mp, `stamina` = ?stamina WHERE `playerid` = ?id";
            MySqlCommand command = new MySqlCommand(SQL, this._mySqlConnection);
            command.Parameters.AddWithValue("?hp", player.playerStats.hp);
            command.Parameters.AddWithValue("?mp", player.playerStats.mp);
            command.Parameters.AddWithValue("?stamina", player.playerStats.stamina);
            command.Parameters.AddWithValue("?id", player.playerId);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error when trying to save player stats "+ e.Message);
                throw;
            }
        }
    }
}