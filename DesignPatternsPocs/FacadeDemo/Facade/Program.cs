using System;
using Facade.Entities;
using Facade.Services;

namespace Facade
{
    public static class Program
    {
        static void Main(string[] args)
        {
            const string zipCode = "98074";

            var cityWeatherService = new CityWeatherService();
            var weather = cityWeatherService.GetTempPerCity(zipCode);

            // bring the result of all service calls together
            Console.WriteLine("The current temperature is {0} F / {1} C in {2}, {3}",
                                weather.TempInFahrenheit,
                                weather.TempInCelcius,
                                weather.CityName,
                                weather.StateName);
        }
    }
}