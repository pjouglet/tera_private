using System;
using TeraServer.Communication.Network.OpCodes.Server;
using TeraServer.Data.DAO;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_SELECT_USER : AClientPacket
    {
        public override void Read()
        {
            int id = ReadD();
            for (int i = 0; i < this.Connection.Account.Players.Count; i++)
            {
                if (this.Connection.Account.Players[i].playerId == id)
                {
                    this.Connection.player = this.Connection.Account.Players[i];
                    break;
                }
            }
            if (this.Connection.player.GM == 1)
            {
                DAOManager.PlayerDao.loadAdminBookmarks(this.Connection.player);
            }
        }

        public override void Process()
        {
            S_SELECT_USER sSelectUser = new S_SELECT_USER();
            sSelectUser.Send(this.Connection);
            
            S_UPDATE_CONTENTS_ON_OFF sUpdateContentsOnOff1 = new S_UPDATE_CONTENTS_ON_OFF(2);
            sUpdateContentsOnOff1.Send(this.Connection);
            
            S_UPDATE_CONTENTS_ON_OFF sUpdateContentsOnOff2 = new S_UPDATE_CONTENTS_ON_OFF(3);
            sUpdateContentsOnOff2.Send(this.Connection);
            
            S_UPDATE_CONTENTS_ON_OFF sUpdateContentsOnOff3 = new S_UPDATE_CONTENTS_ON_OFF(4);
            sUpdateContentsOnOff3.Send(this.Connection);
            
            S_UPDATE_CONTENTS_ON_OFF sUpdateContentsOnOff4 = new S_UPDATE_CONTENTS_ON_OFF(8);
            sUpdateContentsOnOff4.Send(this.Connection);
            
            S_UPDATE_CONTENTS_ON_OFF sUpdateContentsOnOff5 = new S_UPDATE_CONTENTS_ON_OFF(9);
            sUpdateContentsOnOff5.Send(this.Connection);
            
            S_BROCAST_GUILD_FLAG sBrocastGuildFlag = new S_BROCAST_GUILD_FLAG();
            sBrocastGuildFlag.Send(this.Connection);
            
            if (this.Connection.player.GM == 1)
            {
                S_QA_SET_ADMIN_LEVEL sQaSetAdminLevel = new S_QA_SET_ADMIN_LEVEL();
                sQaSetAdminLevel.Send(this.Connection);
            }

            S_LOGIN sLogin = new S_LOGIN(this.Connection.player);
            sLogin.Send(this.Connection);

            S_SHOW_NPC_TO_MAP sShowNpcToMap = new S_SHOW_NPC_TO_MAP();
            sShowNpcToMap.Send(this.Connection);

            S_PLAYER_STAT_UPDATE sPlayerStatUpdate = new S_PLAYER_STAT_UPDATE(this.Connection.player);
            sPlayerStatUpdate.Send(this.Connection);

            S_INVEN sInven = new S_INVEN(this.Connection.player);
            sInven.Send(this.Connection);
            
            S_SKILL_LIST skillList = new S_SKILL_LIST(this.Connection.player);
            skillList.Send(this.Connection);
            
            S_AVAILABLE_SOCIAL_LIST sAvailableSocialList = new S_AVAILABLE_SOCIAL_LIST();
            sAvailableSocialList.Send(this.Connection);
            
            S_CLEAR_QUEST_INFO sClearQuestInfo = new S_CLEAR_QUEST_INFO();
            sClearQuestInfo.Send(this.Connection);
            
            S_DAILY_QUEST_COMPLETE_COUNT sDailyQuestCompleteCount = new S_DAILY_QUEST_COMPLETE_COUNT();
            sDailyQuestCompleteCount.Send(this.Connection);
            
            S_COMPLETED_MISSION_INFO sCompletedMissionInfo = new S_COMPLETED_MISSION_INFO();
            sCompletedMissionInfo.Send(this.Connection);
            
            S_ARTISAN_SKILL_LIST sArtisanSkillList = new S_ARTISAN_SKILL_LIST();
            sArtisanSkillList.Send(this.Connection);
            
            S_ARTISAN_RECIPE_LIST sArtisanRecipeList = new S_ARTISAN_RECIPE_LIST();
            sArtisanRecipeList.Send(this.Connection);
            
            S_PET_INCUBATOR_INFO_CHANGE sPetIncubatorInfoChange = new S_PET_INCUBATOR_INFO_CHANGE();
            sPetIncubatorInfoChange.Send(this.Connection);
            
            S_MOVE_DISTANCE_DELTA sMoveDistanceDelta = new S_MOVE_DISTANCE_DELTA();
            sMoveDistanceDelta.Send(this.Connection);
            
            S_MY_DESCRIPTION sMyDescription = new S_MY_DESCRIPTION();
            sMyDescription.Send(this.Connection);
            
            S_F2P_PremiumUser_Permission sF2PPremiumUserPermission = new S_F2P_PremiumUser_Permission();
            sF2PPremiumUserPermission.Send(this.Connection);
            
            S_HUDDLE_ADDING sHuddleAdding = new S_HUDDLE_ADDING();
            sHuddleAdding.Send(this.Connection);
            
            S_MASSTIGE_STATUS sMasstigeStatus = new S_MASSTIGE_STATUS();
            sMasstigeStatus.Send(this.Connection);
            
            S_AVAILABLE_EVENT_MATCHING_LIST sAvailableEventMatchingList = new S_AVAILABLE_EVENT_MATCHING_LIST();
            sAvailableEventMatchingList.Send(this.Connection);
            
            S_CURRENT_ELECTION_STATE sCurrentElectionState = new S_CURRENT_ELECTION_STATE();
            sCurrentElectionState.Send(this.Connection);

            S_USER_ITEM_EQUIP_CHANGER sUserItemEquipChanger = new S_USER_ITEM_EQUIP_CHANGER(this.Connection.player.playerId);
            sUserItemEquipChanger.Send(this.Connection);
            
            S_FESTIVAL_LIST sFestivalList = new S_FESTIVAL_LIST();
            sFestivalList.Send(this.Connection);
            
            S_LOAD_TOPO sLoadTopo = new S_LOAD_TOPO(this.Connection.player);
            sLoadTopo.Send(this.Connection);
            
            S_LOAD_HINT sLoadHint = new S_LOAD_HINT();
            sLoadHint.Send(this.Connection);
            
            S_ACCOUNT_BENEFIT_LIST sAccountBenefitList = new S_ACCOUNT_BENEFIT_LIST(this.Connection.Account);
            sAccountBenefitList.Send(this.Connection);
            
            S_SEND_USER_PLAY_TIME sSendUserPlayTime = new S_SEND_USER_PLAY_TIME(this.Connection.player);
            sSendUserPlayTime.Send(this.Connection);
            
            S_UPDATE_NPCGUILD sUpdateNpcguild = new S_UPDATE_NPCGUILD(this.Connection.player);
            sUpdateNpcguild.Send(this.Connection);
            
            S_COMPLETED_MISSION_INFO sCompletedMissionInfo2 = new S_COMPLETED_MISSION_INFO();
            sCompletedMissionInfo2.Send(this.Connection);
            
            S_FATIGABILITY_POINT sFatigabilityPoint = new S_FATIGABILITY_POINT();
            sFatigabilityPoint.Send(this.Connection);
            
            S_LOAD_EP_INFO sLoadEpInfo = new S_LOAD_EP_INFO();
            sLoadEpInfo.Send(this.Connection);
        }
    }
}