using System;
using SingletonDemo.StaticConstructorApproach;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test Singleton Static Constructor version1
            var y = Singleton.x;
            var x = Singleton.Instance;
            var x1 = Singleton.Instance;
            var x2 = Singleton.Instance;
            #endregion

        }
    }
}
