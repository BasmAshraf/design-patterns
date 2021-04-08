using System;
using System.Collections.Generic;
using System.Text;

namespace TheOrderKata
{
    public class SwedanTaxCalculation : ITaxCalculation
    {
        public decimal GetTax(Order order)
        {
            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();

            if (destination == order.ShippingDetails.OriginCountry.ToLowerInvariant())
            {
                return order.TotalPrice * 0.25m;
            }

            #region Tax per item
            if (destination == order.ShippingDetails.OriginCountry.ToLowerInvariant())
            {
                decimal totalTax = 0m;
                foreach (var item in order.LineItems)
                {
                    switch (item.Key.ItemType)
                    {
                        case ItemType.Food:
                            totalTax += (item.Key.Price * 0.06m) * item.Value;
                            break;

                        case ItemType.Literature:
                            totalTax += (item.Key.Price * 0.08m) * item.Value;
                            break;

                        case ItemType.Service:
                        case ItemType.Hardware:
                            totalTax += (item.Key.Price * 0.25m) * item.Value;
                            break;
                    }
                }
                return totalTax;
            }
            #endregion

            return 0;
        }
    }
}
