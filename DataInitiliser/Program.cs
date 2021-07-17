using FootballCrimes.DatabaseInitialiser;
using FootballData.Client;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DataInitiliser
{
    class Program
    {

        static void Main(string[] args)
        {
            var serviceCollection = ConfigureServices(new ServiceCollection());
        }

        private static ServiceCollection ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<FootballDataClient>();
            services.Configure<ApiKeys>(Configuration.GetSection("ApiKeys"));

            return services;
        }
    }
}
