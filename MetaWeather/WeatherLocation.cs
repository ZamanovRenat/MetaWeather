using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaWeather
{
    /// <summary>
    /// Класс поиска местоположения
    /// </summary>
    public class WeatherLocation
    {
        public int woeid { get; set; }
        public string title { get; set; }
        public string location_type { get; set; }
        public string latt_long { get; set; }
        public int distance { get; set; }
    }
}
