using Helpers;
using System;

namespace SingletonDemo.NaiveApproach
{
    //Bad code, not thread safe
    public class Singleton
    {
        private static Singleton _instance;
        private Singleton()
        {
            Logger.Log("Constructor invoked");
        }

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called");
                return _instance ??=new Singleton();
            }
        }

        public static void Reset()
        {
            _instance = null;
        }
    }
}
