using System;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;

            var license1 = new MovieLicense("Secret Life of Pets", now,DiscountOption.NoDiscount,LicenceType.TwoDays);
            var license2 = new MovieLicense("Matrix", now,DiscountOption.NoDiscount, LicenceType.LifeLong);

            PrintLicenseDetails(license1);
            PrintLicenseDetails(license2);

            Console.ReadKey();
        }

        private static void PrintLicenseDetails(MovieLicense license)
        {
            Console.WriteLine($"Movie: {license.Movie}");
            Console.WriteLine($"Price: {GetPrice(license)}");
            Console.WriteLine($"Valid for: {GetValidFor(license)}");

            Console.WriteLine();
        }

        private static string GetPrice(MovieLicense license)
        {
            return $"${license.GetPrice():0.00}";
        }

        private static string GetValidFor(MovieLicense license)
        {
            DateTime? expirationDate = license.GetExpirationDate();

            if (expirationDate == null)
                return "Forever";

            TimeSpan timeSpan = expirationDate.Value - DateTime.Now;

            return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
        }
    }
}
