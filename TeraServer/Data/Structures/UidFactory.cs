using System;
using System.Collections.Generic;
using TeraServer.Data.Structures.Enums;

namespace TeraServer.Data.Structures
{
    public class UidFactory
    {
        protected static Dictionary<ObjectFamily, UidFactory> GlobalFactories = new Dictionary<ObjectFamily, UidFactory>();
        protected static object FactoriesLock = new object();
        public static UidFactory Factory(ObjectFamily family)
        {
            lock (FactoriesLock)
            {
                if (!GlobalFactories.ContainsKey(family))
                    GlobalFactories.Add(family, new UidFactory());
            }

            return GlobalFactories[family];
        }
        
        public static UidFactory Factory(object o)
        {
            return Factory(GetFamily(o));
        }
        
        public static ObjectFamily GetFamily(object o)
        {
            if (o is Player)
                return ObjectFamily.Player;

            Console.WriteLine("UidFactory: Unknown object type: {0}", o.GetType().Name);
            return ObjectFamily.System;
        }
        
        protected object Lock = new object();

        protected int NextUid = 1;

        protected Queue<int> FreeUidList = new Queue<int>();

        protected Dictionary<int, Uid> RegisteredObjects = new Dictionary<int, Uid>();

        public Uid FindObject(int uid)
        {
            lock (Lock)
            {
                return RegisteredObjects.ContainsKey(uid)
                    ? RegisteredObjects[uid]
                    : null;
            }
        }

        public int RegisterObject(Uid o)
        {
            lock (Lock)
            {
                int uid = FreeUidList.Count > 0
                    ? FreeUidList.Dequeue()
                    : NextUid++;

                RegisteredObjects.Add(uid, o);

                return uid;
            }
        }

        public void Release(Uid o, int uid)
        {
            if (uid == 0)
                return;

            lock (Lock)
            {
                RegisteredObjects.Remove(uid);
                FreeUidList.Enqueue(uid);
            }
        }
    }
}