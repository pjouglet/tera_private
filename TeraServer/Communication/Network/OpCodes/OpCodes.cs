using System;
using System.Collections.Generic;
using TeraServer.Communication.Network.OpCodes.Client;
using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes
{
    public class OpCodes
    {
        public static Dictionary<short, Type> ClientTypes = new Dictionary<short, Type>();
        public static Dictionary<Type, short> ServerTypes = new Dictionary<Type, short>();

        public static int version = 0x00;

        public static void Init()
        {
            #region client
            
            ClientTypes.Add(unchecked((short) 0xAE2F), typeof(C_LOGIN_ARBITER));
            ClientTypes.Add(unchecked((short) 0x4DBC), typeof(C_CHECK_VERSION));
            ClientTypes.Add(unchecked((short) 0xCD23), typeof(C_SET_VISIBLE_RANGE));
            ClientTypes.Add(unchecked((short) 0x5AF0), typeof(C_GET_USER_LIST));
            ClientTypes.Add(unchecked((short) 0xE8DA), typeof(C_HARDWARE_INFO));
            ClientTypes.Add(unchecked((short) 0xB16B), typeof(C_CAN_CREATE_USER));
            ClientTypes.Add(unchecked((short) 0x81A9), typeof(C_STR_EVALUATE_LIST));
            ClientTypes.Add(unchecked ((short)0xAEF3), typeof(C_WATCHED_MOVIES));
            ClientTypes.Add(unchecked ((short)0xF5AB), typeof(C_REQUEST_VIP_SYSTEM_INFO));
            ClientTypes.Add(unchecked ((short)0xF1E7), typeof(C_CHECK_USERNAME));
            ClientTypes.Add(unchecked ((short)0xCB09), typeof(C_CREATE_USER));
            ClientTypes.Add(unchecked ((short)0x4EDF), typeof(C_DELETE_USER));
            ClientTypes.Add(unchecked ((short)0xDEE5), typeof(C_GET_USER_GUILD_LOGO));
            ClientTypes.Add(unchecked ((short)0xDF1C), typeof(C_CHANGE_USER_LOBBY_SLOT_ID));
            
                    
            #endregion

            #region server
            
            ServerTypes.Add(typeof(S_LOGIN_ARBITER), unchecked ((short)0x6840));
            ServerTypes.Add(typeof(S_ACCOUNT_PACKAGE_LIST), unchecked ((short)0x8DE8));
            ServerTypes.Add(typeof(S_GET_USER_LIST), unchecked ((short)0xD25D));
            ServerTypes.Add(typeof(S_CAN_CREATE_USER), unchecked ((short)0x92D5));
            ServerTypes.Add(typeof(S_LOGIN_ACCOUNT_INFO), unchecked ((short)0x81E7));
            ServerTypes.Add(typeof(S_LOADING_SCREEN_CONTROL_INFO), unchecked ((short)0x6C9C));
            ServerTypes.Add(typeof(S_REMAIN_PLAY_TIME), unchecked ((short)0xB64E));
            ServerTypes.Add(typeof(S_STR_EVALUATE_LIST), unchecked ((short)0xE393));
            ServerTypes.Add(typeof(S_LOAD_CLIENT_ACCOUNT_SETTING), unchecked ((short)0xFDA7));
            ServerTypes.Add(typeof(S_CONFIRM_INVITE_CODE_BUTTON), unchecked ((short)0x7A60));
            ServerTypes.Add(typeof(S_UPDATE_CONTENTS_ON_OFF), unchecked ((short)0x9B6B));
            ServerTypes.Add(typeof(S_SEND_VIP_SYSTEM_INFO), unchecked ((short)0xCA0C));
            ServerTypes.Add(typeof(S_CHECK_USERNAME), unchecked ((short)0xA6A1));
            ServerTypes.Add(typeof(S_CREATE_USER), unchecked ((short)0x5DE2));
            ServerTypes.Add(typeof(S_DELETE_USER), unchecked ((short)0xAD64));
            ServerTypes.Add(typeof(S_GET_USER_GUILD_LOGO), unchecked ((short)0x9D25));
            
            #endregion
        }
    }
}