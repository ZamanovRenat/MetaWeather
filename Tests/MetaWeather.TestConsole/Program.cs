using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MetaWeather.TestConsole
{
    class Program
    {
        private static IHost _hosting;

        public static IHost Hosting => _hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection service)
        {
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
