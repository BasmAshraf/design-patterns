using System;
using System.Collections.Generic;
using System.Text;

namespace TheOrderKata
{
    public class DHLShipping : IShipping
    {
        public void Ship(Order order)
        {
            Console.WriteLine("Shipping using DHL");
        }
    }
}
