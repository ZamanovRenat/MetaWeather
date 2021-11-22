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
        public LocationType Type { get; set; }
        [JsonPropertyName("latt_long")]
        public string Location { get; set; }
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
