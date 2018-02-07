namespace TeraServer.Data.Structures
{
    public abstract class Uid
    {
        private int _uid;
        private UidFactory _uidFactory;

        public int UID
        {
            get
            {
                if(_uid == 0)
                    RegisterUid(_uidFactory);
                return _uid;
            }
        }

        public void RegisterUid(UidFactory uidFactory = null)
        {
            this._uidFactory = uidFactory ?? UidFactory.Factory(this);
            this._uid = this._uidFactory.RegisterObject(this);
        }

        public virtual void Release()
        {
            if(this._uidFactory == null)
                return;
            ReleaseUniqueId();
            this._uidFactory = null;
        }
        
        public void ReleaseUniqueId()
        {
            _uidFactory.Release(this, _uid);
        }
    }
}