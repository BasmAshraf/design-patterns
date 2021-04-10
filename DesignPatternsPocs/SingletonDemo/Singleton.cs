using Helpers;
using System;

namespace SingletonDemo.NaiveApproach
{
    //NaiveApproach, not thread-safe
    //Adding lock, thread-safe
    //Enhace using Lazy<T> without locking it is thread safe by default
    public class Singleton
    {
        #region Singleton Naive approach with locking
        //private static Singleton _instance;
        //private static object padLock = new object();
        //private Singleton()
        //{
        //    Logger.Log("Constructor invoked");
        //}

        //public static Singleton Instance
        //{
        //    get
        //    {
        //        Logger.Log("Instance called");
        //        //lock (padLock)
        //        //{
        //        //    if (_instance == null)
        //        //        _instance = new Singleton();
        //        //    return _instance;
        //        //}

        //        //double checking lock approach
        //        if (_instance == null)
        //        {
        //            lock (padLock)
        //            {
        //                if (_instance == null)
        //                {
        //                    _instance = new Singleton();
        //                }
        //            }
        //        }
        //        return _instance;
        //    }
        //}
        #endregion

        #region Singleton using Lazy<T>
        private static Lazy<Singleton> _instance= new Lazy<Singleton>(()=>new Singleton());
        private Singleton()
        {
            Logger.Log("Constructor invoked");
        }

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called");
                return _instance.Value;
            }
        }

        #endregion
        public static void Reset()
        {
            if(_instance is Singleton)
                 _instance = null;
        }
    }
}
