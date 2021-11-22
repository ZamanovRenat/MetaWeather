using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
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
        /// Метод конвертирования перечисления из строки документа Json
        /// </summary>
        private static readonly JsonSerializerOptions __JsonOptions = new()
        {
            Converters =
            {
                new JsonStringEnumConverter(),
                //new JsonCoordinateConverter()
            }
        };
        /// <summary>
        /// Метод получения географических координат по названию населенного пункта
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public async Task<WeatherLocation[]> GetLocationByName(string Name, CancellationToken Cancel = default)
        {
            return await _client
                .GetFromJsonAsync<WeatherLocation[]>($"/api/location/search/?query={Name}", __JsonOptions, Cancel)
                .ConfigureAwait(false);
        }
    }
}
