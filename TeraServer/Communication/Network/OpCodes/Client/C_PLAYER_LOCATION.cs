﻿using System;
using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_PLAYER_LOCATION : AClientPacket
    {
        private float x;
        private float y;
        private float z;
        private float tx;
        private float ty;
        private float tz;
        private short heading;
        private short angle;
        private int type;
        private int speed;
        public override void Read()
        {
            this.x = ReadF();
            this.y = ReadF();
            this.z = ReadF();
            this.heading = (short)ReadH();
            this.angle = (short)ReadH();
            this.tx = ReadF();
            this.ty = ReadF();
            this.tz = ReadF();
            this.type = ReadD();
            this.speed = ReadH();
            ReadB(1);
        }

        public override void Process()
        {
            this.Connection.player.posX = x;
            this.Connection.player.posY = y;
            this.Connection.player.posZ = z;
            this.Connection.player.heading = heading;
            
            S_USER_LOCATION sUserLocation = new S_USER_LOCATION(this.Connection.player, x, y, z, tx, ty, tz, heading, type, speed, angle);
            Connection.broadcast(sUserLocation);
        }
    }
}