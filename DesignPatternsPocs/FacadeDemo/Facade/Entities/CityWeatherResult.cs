using System;
using System.Collections.Generic;
using System.Text;

namespace Facade.Entities
{
    public class CityWeatherResult
    {
        public string CityName { get; set; }
        public string StateName { get; set; }
        public int TempInCelcius { get; set; }
        public int TempInFahrenheit { get; set; }
    }
}
