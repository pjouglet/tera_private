using System;
using TeraServer.Communication.Network;
using TeraServer.Communication.Network.OpCodes.Server;
using TeraServer.Data.DAO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Logic
{
    public class AccountLogic
    {
        public static void AuthorizeLogin(Connection connection, string accountName, string ticket, int language)
        {
            Account account = DAOManager.AccountDao.LoadAccount(accountName, ticket);
            if (account != null)
                connection.Account = account;
            S_LOADING_SCREEN_CONTROL_INFO sLoadingScreenControlInfo = new S_LOADING_SCREEN_CONTROL_INFO();
            sLoadingScreenControlInfo.Send(connection);
            S_REMAIN_PLAY_TIME sRemainPlayTime = new S_REMAIN_PLAY_TIME();
            sRemainPlayTime.Send(connection);
            S_LOGIN_ARBITER s_login_arbiter = new S_LOGIN_ARBITER(language, ((account != null) ? true: false));
            s_login_arbiter.Send(connection);
            S_LOGIN_ACCOUNT_INFO s_login_account_info = new S_LOGIN_ACCOUNT_INFO();
            s_login_account_info.Send(connection);
        }
    }
}