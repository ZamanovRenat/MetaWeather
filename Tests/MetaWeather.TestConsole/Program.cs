using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MetaWeather.TestConsole
{
    class Program
    {
        private static IHost _hosting;

        public static IHost Hosting => _hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static IServiceProvider Services => Hosting.Services;
        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddHttpClient<MetaWeatherClient>(client => client.BaseAddress = new Uri(host.Configuration["MetaWeather"]));
        }

        static async Task Main(string[] args)
        {
            using var host = Hosting;
            await host.StartAsync();

            var weather = Services.GetRequiredService<MetaWeatherClient>();

            var location = await weather.GetLocation("Moscow");

            var locations = await weather.GetLocation(location[0].Location);

            Console.WriteLine(locations.ToString());

            Console.WriteLine("Завершено!");
            Console.ReadLine();
            await host.StopAsync();
        }
    }
}
