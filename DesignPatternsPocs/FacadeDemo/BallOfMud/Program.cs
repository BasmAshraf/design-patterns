using System;
using BallOfMud.Services;

namespace BallOfMud
{
    class Program
    {
        static void Main(string[] args)
        {
            BigClassFacade bigClassFacade = new BigClassFacade();

            bigClassFacade.SetValue(3);

            bigClassFacade.IncrementValue();
            bigClassFacade.IncrementValue();
            bigClassFacade.IncrementValue();

            bigClassFacade.DecrementValue();

            Console.WriteLine($"Final Number : {bigClassFacade.GetValue()}");
        }
    }
}