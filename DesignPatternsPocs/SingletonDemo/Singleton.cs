using Helpers;
using System;

namespace SingletonDemo.NaiveApproach
{
    //NaiveApproach, not thread-safe
    //Adding lock, thread-safe
    public class Singleton
    {
        private static Singleton _instance;
        private static object padLock = new object();
        private Singleton()
        {
            Logger.Log("Constructor invoked");
        }

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called");
                //lock (padLock)
                //{
                //    if (_instance == null)
                //        _instance = new Singleton();
                //    return _instance;
                //}

                //double checking lock approach
                if (_instance == null)
                {
                    lock (padLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                        }
                    }
                }
                return _instance;
            }
        }

        public static void Reset()
        {
            _instance = null;
        }
    }
}
