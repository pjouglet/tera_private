﻿using System.IO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Server
{
    public class S_SEND_USER_PLAY_TIME : AServerPacket
    {
        private Player _player;

        public S_SEND_USER_PLAY_TIME(Player player)
        {
            this._player = player;
        }
        
        public override void Write(BinaryWriter writer)
        {
            WriteLong(writer, Utils.Funcs.GetRoundedUtc());//time
            WriteInt32(writer, _player.creationTime);//creationtime
        }
    }
}