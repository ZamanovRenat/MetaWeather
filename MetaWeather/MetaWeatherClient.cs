using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using MetaWeather.Models;

namespace MetaWeather
{
    public class MetaWeatherClient
    {
        private readonly HttpClient _client;

        public MetaWeatherClient(HttpClient Client)
        {
            _client = Client;
        }
        ///// <summary>
        ///// Метод конвертирования перечисления из строки документа Json
        ///// </summary>
        //private static readonly JsonSerializerOptions __JsonOptions = new()
        //{
        //    Converters =
        //    {
        //        new JsonStringEnumConverter(),
        //        new JsonCoordinateConverter()
        //    }
        //};
        /// <summary>
        /// Метод получения географических координат по названию населенного пункта
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public async Task<WeatherLocation[]> GetLocation(string Name, CancellationToken Cancel = default)
        {
            return await _client
                .GetFromJsonAsync<WeatherLocation[]>($"/api/location/search/?query={Name}", /*__JsonOptions,*/ Cancel)
                .ConfigureAwait(false);
        }
        /// <summary>
        /// Метод получения местоположения по координатам
        /// </summary>
        /// <param name="Location"></param>
        /// <param name="Cancel"></param>
        /// <returns></returns>
        public async Task<WeatherLocation[]> GetLocation((double Latitude, double Longitude) Location, CancellationToken Cancel = default)
        {
            return await _client
                .GetFromJsonAsync<WeatherLocation[]>($"/api/location/search/?lattlong={Location.Latitude.ToString(CultureInfo.InvariantCulture)},{Location.Longitude.ToString(CultureInfo.InvariantCulture)}", Cancel)
                .ConfigureAwait(false);
        }
        /// <summary>
        /// Получение информации о местоположении по <param name="WoeId"></param>
        /// </summary>
        /// <param name="WoeId"></param>
        /// <param name="Cancel"></param>
        /// <returns></returns>
        public async Task<LocationInfo> GetInfo(int WoeId, CancellationToken Cancel = default)
        {
            return await _client.GetFromJsonAsync<LocationInfo>($"/api/location/{WoeId}", Cancel).ConfigureAwait(false);
        }

        public Task<LocationInfo> GetInfo(WeatherLocation Location, CancellationToken Cancel = default) =>
            GetInfo(Location.Id, Cancel);
        /// <summary>
        /// Получение информации о погоде
        /// </summary>
        /// <param name="WoeId"></param>
        /// <param name="Time"></param>
        /// <param name="Cancel"></param>
        /// <returns></returns>
        public async Task<WeatherInfo[]> GetWeather(int WoeId, DateTime Time, CancellationToken Cancel = default)
        {
            return await _client
                .GetFromJsonAsync<WeatherInfo[]>($"/api/location/{WoeId}/{Time:yyyy}/{Time:MM}/{Time:dd}/", Cancel)
                .ConfigureAwait(false);
        }

        public Task<WeatherInfo[]> GetWeather(LocationInfo Location, DateTime Time, CancellationToken Cancel = default) =>
            GetWeather(Location.Id, Time, Cancel);

        public Task<WeatherInfo[]> GetWeather(WeatherLocation Location, DateTime Time, CancellationToken Cancel = default) =>
            GetWeather(Location.Id, Time, Cancel);
    }
}
