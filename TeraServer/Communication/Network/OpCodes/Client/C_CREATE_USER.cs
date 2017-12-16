using System;
using System.IO;
using TeraServer.Communication.Network.OpCodes.Server;
using TeraServer.Data.DAO;
using TeraServer.Data.Structures;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_CREATE_USER : AClientPacket
    {
        private int gender;
        private int race;
        private int classId;
        private byte[] data1;
        private string username;
        private byte[] details1;
        private byte[] details2;

        private Player _player;
        
        public override void Read()
        {
            _player = new Player();
            short nameOffset = (short) ReadH();
            short details1Offset = (short) ReadH();
            short details1Length = (short) ReadH();
            short details2Offset = (short) ReadH();
            short details2Length = (short) ReadH();
            _player.gender = ReadD();
            _player.race = ReadD();
            _player.classId = ReadD();
            _player.details3 = ReadB(8);

            Reader.BaseStream.Seek(nameOffset-4, SeekOrigin.Begin);
            _player.name = ReadS();
            _player.details1 = ReadB(details1Length);
            _player.details2 = ReadB(details2Length);
        }

        public override void Process()
        {
            DAOManager.PlayerDao.SaveNewPlayer(this._player, this.Connection.Account.AccountID);
            this.Connection.Account.Players =
                DAOManager.PlayerDao.LoadAccountPlayers(this.Connection.Account.AccountID);
            S_CREATE_USER sCreateUser = new S_CREATE_USER();
            sCreateUser.Send(this.Connection);
            
        }
    }
}