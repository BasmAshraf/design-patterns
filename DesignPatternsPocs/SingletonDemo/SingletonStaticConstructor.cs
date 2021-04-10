using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonDemo.StaticConstructorApproach
{
    public class Singleton
    {
        #region Static Constructor version1
        //private static readonly Singleton _instanace = new Singleton();
        //public static string x = "hamada";
        //private Singleton()
        //{

        //}

        //static Singleton()
        //{

        //}

        //public static Singleton Instance
        //{
        //    get
        //    {
        //        return _instanace;
        //    }
        //}
        #endregion

        #region Static Constructor version2 (Modified)
        //To fix the issue of instatiating the instance from any static member so here we try to instantiate on demand as much as we can
        public static string x = "hamada";
        private Singleton()
        {

        }

        static Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                return Nested._instanace;
            }
        }
        private class Nested
        {
            public static readonly Singleton _instanace = new Singleton();
            static Nested()
            {
            }
        }
        #endregion
    }
}
