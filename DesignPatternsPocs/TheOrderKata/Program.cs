using System;

namespace TheOrderKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                }
            };

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);

            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();

            if (destination == "sweden")
            {
                order.TaxCalculation = new SwedanTaxCalculation();
            }

            if (destination == "us")
            {
                order.TaxCalculation = new USTaxCalculation();
            }
            order.InvoiceCreation = new EmailInvoiceCreation();
            Console.WriteLine(order.GetTax());
            order.GenerateInvoice();
        }
    }
}
