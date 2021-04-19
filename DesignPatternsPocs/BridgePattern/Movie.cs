using System;

namespace BridgePattern
{
    public class MovieLicense
    {
        private DiscountOption _discount;
        private LicenceType _licenceType;
        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        public MovieLicense(string movie, DateTime purchaseTime, DiscountOption discount, LicenceType licenceType)
        {
            _discount = discount;
            _licenceType = licenceType;
            Movie = movie;
            PurchaseTime = purchaseTime;
        }

        private decimal GetOriginalPrice()
        {
            return _licenceType switch
            {
                LicenceType.TwoDays => 4,
                LicenceType.LifeLong => 8,
                _ => throw new NotSupportedException(),
            };
        }
        private decimal GetDiscount()
        {
            return _discount switch
            {
                DiscountOption.NoDiscount => 1,
                DiscountOption.Senior => 0.2m,
                DiscountOption.Military => 0.8m,
                _ => throw new NotSupportedException(),
            };
        }
        private DateTime? GetBaseExpirationDate()
        {
            return _licenceType switch
            {
                LicenceType.TwoDays => PurchaseTime.AddDays(2) as DateTime?,
                LicenceType.LifeLong => null,

                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public decimal GetPrice()
        {
            return GetOriginalPrice() * GetDiscount();
        }

        public DateTime? GetExpirationDate()
        {
            return GetBaseExpirationDate();
        }
    }

    public enum DiscountOption
    {
        NoDiscount,
        Senior,
        Military
    }

    public enum LicenceType
    {
        TwoDays,
        LifeLong
    }
}
