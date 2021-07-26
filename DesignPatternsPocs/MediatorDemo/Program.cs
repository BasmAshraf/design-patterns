using MediatorDemo.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new MediatorConcreate();
            var colleagueOne= mediator.CreateColleague<ColleagueOne>();
            var colleagueTwo=mediator.CreateColleague<ColleagueTwo>();

            colleagueOne.Send("Hello from Colleague one");
            colleagueTwo.Send("Hello from Colleague two");
            Console.Read();
        }
    }
}
