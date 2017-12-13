﻿using System;
using MySql.Data.MySqlClient;
using TeraServer.Data.Structures;

namespace TeraServer.Data.DAO
{
    public class AccountDAO : BaseDAO
    {
        private MySqlConnection _mySqlConnection;
        
        public AccountDAO(string str) : base(str)
        {
            this._mySqlConnection = new MySqlConnection(str);
            this._mySqlConnection.Open();
            
            Console.WriteLine("[DAO] : {0} accounts in the database.", this.LoadTotalAccount());
        }

        private int LoadTotalAccount()
        {
            string SQL = "SELECT count(id) FROM `accounts`";
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

        public Account LoadAccount(string login, string ticket)
        {
            string SQL = "SELECT * FROM `accounts` WHERE `login` = ?login AND `password` = ?ticket";
            MySqlCommand mySqlCommand = new MySqlCommand(SQL, this._mySqlConnection);
            mySqlCommand.Parameters.AddWithValue("?login", login);
            mySqlCommand.Parameters.AddWithValue("?ticket", ticket);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            
            Account account = new Account();
            if (reader.HasRows)
            {
                reader.Read();
                account.AccountID = (int)reader.GetValue(reader.GetOrdinal("id"));
                account.AccountName = reader.GetValue(reader.GetOrdinal("login")).ToString();
                account.Ticket = reader.GetValue(reader.GetOrdinal("password")).ToString();
                account.Email = reader.GetValue(reader.GetOrdinal("email")).ToString();
                account.IP = reader.GetValue(reader.GetOrdinal("ip")).ToString();
                account.Players = DAOManager.PlayerDao.LoadAccountPlayers(account.AccountID);
            }
            reader.Close();
            return (account.AccountName == string.Empty) ? null : account;
        }
    }
}