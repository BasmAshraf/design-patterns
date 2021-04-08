using System;
using System.Collections.Generic;
using System.Text;

namespace TheOrderKata
{
    public interface IInvoiceCreation
    {
        void Generate(Order order);
    }
}
