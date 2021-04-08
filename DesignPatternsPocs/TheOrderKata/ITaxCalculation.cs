using System;
using System.Collections.Generic;
using System.Text;

namespace TheOrderKata
{
    public interface ITaxCalculation
    {
        decimal GetTax(Order order);
    }
}
