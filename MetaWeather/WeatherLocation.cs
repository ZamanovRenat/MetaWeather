using System.Text.Json.Serialization;

namespace MetaWeather
{
    /// <summary>
    /// Класс поиска местоположения
    /// </summary>
    public class WeatherLocation
    {
        //Указание в атрибуте имени в документе Json
        [JsonPropertyName("woeid")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("location_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LocationType Type { get; set; }
        [JsonPropertyName("latt_long")]
        [JsonConverter(typeof(JsonCoordinateConverter))]
        public (double Latitude, double Longitude) Location { get; set; }
        [JsonPropertyName("distance")]
        public int Distance { get; set; }
    }

    public enum LocationType
    {
        City,
        Region,
        State,
        Province,
        Country,
        Continent
    }
}
