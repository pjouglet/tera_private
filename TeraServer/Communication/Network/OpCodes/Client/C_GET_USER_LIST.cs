﻿using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_GET_USER_LIST : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_GET_USER_LIST s_get_user_list = new S_GET_USER_LIST(this.Connection);
            s_get_user_list.Send(this.Connection);
            S_LOAD_CLIENT_ACCOUNT_SETTING sLoadClientAccountSetting = new S_LOAD_CLIENT_ACCOUNT_SETTING();
            sLoadClientAccountSetting.Send(this.Connection);
            S_ACCOUNT_PACKAGE_LIST sAccountPackageList = new S_ACCOUNT_PACKAGE_LIST(this.Connection.Account);
            sAccountPackageList.Send(this.Connection);
            S_CONFIRM_INVITE_CODE_BUTTON sConfirmInviteCodeButton = new S_CONFIRM_INVITE_CODE_BUTTON();
            sConfirmInviteCodeButton.Send(this.Connection);
            S_UPDATE_CONTENTS_ON_OFF sUpdateContentsOnOff = new S_UPDATE_CONTENTS_ON_OFF(2);
            sUpdateContentsOnOff.Send(this.Connection);
            sUpdateContentsOnOff = new S_UPDATE_CONTENTS_ON_OFF(3);
            sUpdateContentsOnOff.Send(this.Connection);
            sUpdateContentsOnOff = new S_UPDATE_CONTENTS_ON_OFF(4);
            sUpdateContentsOnOff.Send(this.Connection);
            sUpdateContentsOnOff = new S_UPDATE_CONTENTS_ON_OFF(8);
            sUpdateContentsOnOff.Send(this.Connection);
            sUpdateContentsOnOff = new S_UPDATE_CONTENTS_ON_OFF(9);
            sUpdateContentsOnOff.Send(this.Connection);
        }
    }
}