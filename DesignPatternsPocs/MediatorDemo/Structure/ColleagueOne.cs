using System;

namespace MediatorDemo.Structure
{
    public class ColleagueOne : Colleague
    {
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"ColleageOne recieved message: {message}");
        }
    }
}
