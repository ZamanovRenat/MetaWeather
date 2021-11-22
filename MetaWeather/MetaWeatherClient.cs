using System.Net.Http;

namespace MetaWeather
{
    public class MetaWeatherClient
    {
        private readonly HttpClient _client;

        public MetaWeatherClient(HttpClient Client)
        {
            _client = Client;
        }
    }
}
