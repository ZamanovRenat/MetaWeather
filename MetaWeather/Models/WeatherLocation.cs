using System.Text.Json.Serialization;
using MetaWeather.Models;

namespace MetaWeather
{
    /// <summary>
    /// Класс поиска местоположения
    /// </summary>
    public class WeatherLocation : Location
    {
        [JsonPropertyName("distance")]
        public int Distance { get; set; }

        public override string ToString()
        {
            return $"{Title}[{Id}]({Type}):{Coordinates} ({Distance})";
        }
    }
}
