using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MMTShopClient.Behaviours;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MMTShopClient
{
    class Program
    {
        private static IConfiguration configuration;

        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            await scope.ServiceProvider.GetRequiredService<MMTShopClientService>().RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                    .AddJsonFile("appsettings.json")
                    .Build();
                    services.AddSingleton(configuration);
                    services.AddLogging(ops => ops.SetMinimumLevel(LogLevel.Warning));
                    services.AddHttpClient("default", client => client.BaseAddress = new Uri(configuration["Api:HostUrl"]));

                    services.AddSingleton<IProductWriter, ConsoleProductWriter>();
                    services.AddSingleton<ICategoryWriter, ConsoleCategoryWriter>();

                    services.AddSingleton<IListCategoriesBehaviour, APIListCategoriesBehaviour>();
                    services.AddSingleton<IListFeaturedProductsBehaviour, APIListFeaturedProductsBehaviour>();
                    services.AddSingleton<IListCategoryProductsBehaviour, APIListCategoryProductsBehaviour>();

                    services.AddSingleton<MMTShopClientService>();
                });
        }
    }
}
