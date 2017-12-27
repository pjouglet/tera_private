using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_LOAD_TOPO_FIN : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_ONGOING_LEVEL_EVENT_LIST sOngoingLevelEventList = new S_ONGOING_LEVEL_EVENT_LIST();
            sOngoingLevelEventList.Send(this.Connection);
            
            S_ONGOING_HUNTING_EVENT_LIST sOngoingHuntingEventList = new S_ONGOING_HUNTING_EVENT_LIST();
            sOngoingHuntingEventList.Send(this.Connection);
            
            S_VISITED_SECTION_LIST sVisitedSectionList = new S_VISITED_SECTION_LIST();
            sVisitedSectionList.Send(this.Connection);
            
            S_REQUEST_INVITE_GUILD_TAG sRequestInviteGuildTag = new S_REQUEST_INVITE_GUILD_TAG();
            sRequestInviteGuildTag.Send(this.Connection);
            
            S_UPDATE_FRIEND_INFO sUpdateFriendInfo = new S_UPDATE_FRIEND_INFO();
            sUpdateFriendInfo.Send(this.Connection);
            
            //setttings
            
            S_EP_SYSTEM_DAILY_EVENT_EXP_ON_OFF sEpSystemDailyEventExpOnOff = new S_EP_SYSTEM_DAILY_EVENT_EXP_ON_OFF();
            sEpSystemDailyEventExpOnOff.Send(this.Connection);
            
            S_SPAWN_ME sSpawnMe = new S_SPAWN_ME(this.Connection.player);
            sSpawnMe.Send(this.Connection);
            
            S_ATTENDANCE_EVENT_REWARD_COUNT sAttendanceEventRewardCount = new S_ATTENDANCE_EVENT_REWARD_COUNT();
            sAttendanceEventRewardCount.Send(this.Connection);
            
            S_ACCOUNT_BENEFIT_LIST sAccountBenefitList = new S_ACCOUNT_BENEFIT_LIST(this.Connection.Account);
            sAccountBenefitList.Send(this.Connection);
            
            S_PLAYER_CHANGE_ALL_PROF sPlayerChangeAllProf = new S_PLAYER_CHANGE_ALL_PROF();
            sPlayerChangeAllProf.Send(this.Connection);
            
            S_PARCEL_READ_RECV_STATUS sParcelReadRecvStatus = new S_PARCEL_READ_RECV_STATUS();
            sParcelReadRecvStatus.Send(this.Connection);
            
            S_F2P_PremiumUser_Permission sF2PPremiumUserPermission = new S_F2P_PremiumUser_Permission();
            sF2PPremiumUserPermission.Send(this.Connection);
            
            S_USER_STATUS sUserStatus = new S_USER_STATUS(this.Connection.player);
            sUserStatus.Send(this.Connection);
            
            S_LOAD_ACHIEVEMENT_LIST sLoadAchievementList = new S_LOAD_ACHIEVEMENT_LIST(this.Connection.player);
            sLoadAchievementList.Send(this.Connection);
            
            S_UPDATE_ACHIEVEMENT_PROGRESS sUpdateAchievementProgress = new S_UPDATE_ACHIEVEMENT_PROGRESS(this.Connection.player);
            sUpdateAchievementProgress.Send(this.Connection);

            if (this.Connection.player.GM == 1)
            {
                S_ADMIN_GM_SKILL sAdminGmSkill = new S_ADMIN_GM_SKILL(0, 0);
                sAdminGmSkill.Send(this.Connection);
                
                S_CHANGE_RELATION sChangeRelation = new S_CHANGE_RELATION(this.Connection.player, 26);
                sChangeRelation.Send(this.Connection);
            }
            
        }
    }
}