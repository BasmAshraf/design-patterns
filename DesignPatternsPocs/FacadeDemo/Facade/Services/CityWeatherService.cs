using Facade.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facade.Services
{
    public class CityWeatherService
    {
        WeatherService _weatherService;
        GeoLookupService _geoLookupService;
        ConverterService _converterService;

        public CityWeatherService() : this(new WeatherService(), new GeoLookupService(), new ConverterService())
        { }

        private CityWeatherService(WeatherService weatherService, GeoLookupService geoLookupService, ConverterService converterService)
        {
            _weatherService = weatherService;
            _geoLookupService = geoLookupService;
            _converterService = converterService;
        }

        public CityWeatherResult GetTempPerCity(string zipCode)
        {
            var result = new CityWeatherResult();
            var city = _geoLookupService.GetCityForZipCode(zipCode);
            var state = _geoLookupService.GetStateForZipCode(zipCode);
            result.CityName = city.Name;
            result.StateName = state.Name;
            var fahrenheit = _weatherService.GetTempFahrenheit(city, state);
            result.TempInFahrenheit = fahrenheit;
            var celcius = _converterService.ConvertFahrenheitToCelcious(fahrenheit);
            result.TempInCelcius = celcius;
            return result;
        }
    }
}
