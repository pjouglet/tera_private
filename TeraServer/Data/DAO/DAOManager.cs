namespace TeraServer.Data.DAO
{
    public static class DAOManager
    {
        public static AccountDAO AccountDao;
        public static PlayerDAO PlayerDao;
        
        public static void Initialise(string str)
        {
            AccountDao = new AccountDAO(str);
            PlayerDao = new PlayerDAO(str);
            
            PlayerDAO.UpdatePlayerThread.Start();
        }
    }
}