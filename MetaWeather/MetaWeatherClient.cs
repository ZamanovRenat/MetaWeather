using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MetaWeather
{
    public class MetaWeatherClient
    {
        private readonly HttpClient _client;

        public MetaWeatherClient(HttpClient Client)
        {
            _client = Client;
        }
        /// <summary>
        /// Метод получения географических координат по названию населенного пункта
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public async Task<WeatherLocation[]> GetLocationByName(string Name)
        {
            return await _client.GetFromJsonAsync<WeatherLocation[]>($"/api/location/search/?query={Name}");
        }
    }
}
