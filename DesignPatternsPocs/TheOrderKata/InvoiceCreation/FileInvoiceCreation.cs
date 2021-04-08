using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TheOrderKata
{
    public class FileInvoiceCreation : InvoiceCreation
    {
        public override void Generate(Order order)
        {
            using (var stream = new StreamWriter($"invoice_{Guid.NewGuid()}.txt"))
            {
                stream.Write(GenerateTextInvoice(order));

                stream.Flush();
            }
        }
    }
}
