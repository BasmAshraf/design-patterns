using System;

namespace MediatorDemo.Structure
{
    public class ColleagueTwo : Colleague
    {
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"ColleageTwo recieved message: {message}");
        }
    }
}
