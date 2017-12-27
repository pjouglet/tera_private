using System;
using System.Collections.Generic;
using TeraServer.Communication.Network.OpCodes.Client;
using TeraServer.Communication.Network.OpCodes.Serve;
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
            
            ClientTypes.Add(unchecked ((short)0x8EE1), typeof(C_SAVE_CLIENT_ACCOUNT_SETTING));
            ClientTypes.Add(unchecked ((short)0x7EC4), typeof(C_SELECT_USER));
            ClientTypes.Add(unchecked ((short)0xAD75), typeof(C_LOAD_TOPO_FIN));
            ClientTypes.Add(unchecked ((short)0xAED9), typeof(C_TRADE_BROKER_HIGHEST_ITEM_LEVEL));
            ClientTypes.Add(unchecked ((short)0xAE9C), typeof(C_SERVER_TIME));
            ClientTypes.Add(unchecked ((short)0x5DFE), typeof(C_REQUEST_GUILD_PERK_LIST));
            ClientTypes.Add(unchecked ((short)0x837C), typeof(C_UPDATE_CONTENTS_PLAYTIME));
            ClientTypes.Add(unchecked ((short)0xB15B), typeof(C_REQUEST_INGAMESTORE_PRODUCT_LIST));
            ClientTypes.Add(unchecked ((short)0x87BB), typeof(C_PLAYER_LOCATION));
            ClientTypes.Add(unchecked ((short)0x597E), typeof(C_EVENT_GUIDE));
            ClientTypes.Add(unchecked ((short)0xAACE), typeof(C_GUARD_PK_POLICY));
            ClientTypes.Add(unchecked ((short)0x7E23), typeof(C_REIGN_INFO));
            ClientTypes.Add(unchecked ((short)0xD3BA), typeof(C_SIMPLE_TIP_REPEAT_CHECK));
            
                    
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
            
            ServerTypes.Add(typeof(S_SELECT_USER), unchecked ((short)0x7FF7));
            ServerTypes.Add(typeof(S_BROCAST_GUILD_FLAG), unchecked ((short)0xDF2F));
            ServerTypes.Add(typeof(S_LOGIN), unchecked ((short)0xD3AE));
            ServerTypes.Add(typeof(S_SHOW_NPC_TO_MAP), unchecked ((short)0xCFDC));
            ServerTypes.Add(typeof(S_INVEN), unchecked ((short)0x5221));
            ServerTypes.Add(typeof(S_AVAILABLE_SOCIAL_LIST), unchecked ((short)0xF2AA));
            ServerTypes.Add(typeof(S_CLEAR_QUEST_INFO), unchecked ((short)0xF64C));
            ServerTypes.Add(typeof(S_DAILY_QUEST_COMPLETE_COUNT), unchecked ((short)0xD1FF));
            ServerTypes.Add(typeof(S_COMPLETED_MISSION_INFO), unchecked ((short)0x5DD4));
            ServerTypes.Add(typeof(S_ARTISAN_SKILL_LIST), unchecked ((short)0xC68E));
            ServerTypes.Add(typeof(S_ARTISAN_RECIPE_LIST), unchecked ((short)0xF725));
            ServerTypes.Add(typeof(S_PET_INCUBATOR_INFO_CHANGE), unchecked ((short)0x63E3));
            ServerTypes.Add(typeof(S_MOVE_DISTANCE_DELTA), unchecked ((short)0xFBF6));
            ServerTypes.Add(typeof(S_MY_DESCRIPTION), unchecked ((short)0x5C53));
            ServerTypes.Add(typeof(S_F2P_PremiumUser_Permission), unchecked ((short)0xDF6E));
            ServerTypes.Add(typeof(S_HUDDLE_ADDING), unchecked ((short)0x5633));
            ServerTypes.Add(typeof(S_MASSTIGE_STATUS), unchecked ((short)0xC1F9));
            ServerTypes.Add(typeof(S_AVAILABLE_EVENT_MATCHING_LIST), unchecked ((short)0x7AC9));
            ServerTypes.Add(typeof(S_CURRENT_ELECTION_STATE), unchecked ((short)0x525E));
            ServerTypes.Add(typeof(S_USER_ITEM_EQUIP_CHANGER), unchecked ((short)0xA50A));
            ServerTypes.Add(typeof(S_FESTIVAL_LIST), unchecked ((short)0x93A9));
            ServerTypes.Add(typeof(S_LOAD_TOPO), unchecked ((short)0xBF99));
            ServerTypes.Add(typeof(S_LOAD_HINT), unchecked ((short)0xD24C));
            ServerTypes.Add(typeof(S_ACCOUNT_BENEFIT_LIST), unchecked ((short)0x60CC));
            ServerTypes.Add(typeof(S_SEND_USER_PLAY_TIME), unchecked ((short)0xD094));
            //ServerTypes.Add(typeof(S_PCBANGINVENTORY_DATALIST), unchecked ((short)0xE6C7));
            ServerTypes.Add(typeof(S_UPDATE_NPCGUILD), unchecked ((short)0xDF3F));
            ServerTypes.Add(typeof(S_FATIGABILITY_POINT), unchecked ((short)0xD274));
            ServerTypes.Add(typeof(S_LOAD_EP_INFO), unchecked ((short)0x7D62));
            ServerTypes.Add(typeof(S_TRADE_BROKER_HIGHEST_ITEM_LEVEL), unchecked ((short)0xF195));
            ServerTypes.Add(typeof(S_SERVER_TIME), unchecked ((short)0xE7EC));
            ServerTypes.Add(typeof(S_ONGOING_LEVEL_EVENT_LIST), unchecked ((short)0xFAD0));
            ServerTypes.Add(typeof(S_ONGOING_HUNTING_EVENT_LIST), unchecked ((short)0x6DA4));
            ServerTypes.Add(typeof(S_VISITED_SECTION_LIST), unchecked ((short)0x7192));
            ServerTypes.Add(typeof(S_REQUEST_INVITE_GUILD_TAG), unchecked ((short)0xD8B7));
            ServerTypes.Add(typeof(S_UPDATE_FRIEND_INFO), unchecked ((short)0xBD30));
            ServerTypes.Add(typeof(S_EP_SYSTEM_DAILY_EVENT_EXP_ON_OFF), unchecked ((short)0x9405));
            ServerTypes.Add(typeof(S_SPAWN_ME), unchecked ((short)0x7BC3));
            ServerTypes.Add(typeof(S_ATTENDANCE_EVENT_REWARD_COUNT), unchecked ((short)0xDB3A));
            ServerTypes.Add(typeof(S_PLAYER_CHANGE_ALL_PROF), unchecked ((short)0x91A7));
            ServerTypes.Add(typeof(S_PARCEL_READ_RECV_STATUS), unchecked ((short)0xB7E1));
            ServerTypes.Add(typeof(S_USER_STATUS), unchecked ((short)0x912C));
            ServerTypes.Add(typeof(S_LOAD_ACHIEVEMENT_LIST), unchecked ((short)0xFC0D));
            ServerTypes.Add(typeof(S_UPDATE_ACHIEVEMENT_PROGRESS), unchecked ((short)0xE824));            
            ServerTypes.Add(typeof(S_QA_SET_ADMIN_LEVEL), unchecked ((short)0xD07E));            
            ServerTypes.Add(typeof(S_ADMIN_GM_SKILL), unchecked ((short)0xCBB0));            
            ServerTypes.Add(typeof(S_CHANGE_RELATION), unchecked ((short)0xA7A4));         
            ServerTypes.Add(typeof(S_INGAMESHOP_CATEGORY_BEGIN), unchecked ((short)0xED4D));         
            ServerTypes.Add(typeof(S_INGAMESHOP_CATEGORY_END), unchecked ((short)0xAB38));         
            ServerTypes.Add(typeof(S_INGAMESHOP_PRODUCT_BEGIN), unchecked ((short)0xA7CC));         
            ServerTypes.Add(typeof(S_INGAMESHOP_PRODUCT_END), unchecked ((short)0x5878));         
            ServerTypes.Add(typeof(S_USER_LOCATION), unchecked ((short)0xD9C7));         
            ServerTypes.Add(typeof(S_GUARD_PK_POLICY), unchecked ((short)0x98F7));         
            ServerTypes.Add(typeof(S_REIGN_INFO), unchecked ((short)0xA55E));         
            ServerTypes.Add(typeof(S_SIMPLE_TIP_REPEAT_CHECK), unchecked ((short)0xCA11));         
            
            #endregion
        }
    }
}