using System;
using MySql.Data.MySqlClient;

namespace TeraServer.Data.DAO
{
    public abstract class BaseDAO
    {
        private string mysqlString = string.Empty;
        public static MySqlConnection Connection;

        public BaseDAO(string str)
        {
            this.mysqlString = str;
            Connection = new MySqlConnection(this.mysqlString);
            try
            {
                Connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when trying to open MySQL connection !");

            }
            finally
            {
                Connection.Close();
            }
        }
    }
}