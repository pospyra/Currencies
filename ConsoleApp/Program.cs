using Currencies.BLL.IServices;
using Currencies.BLL.Services;
using Currencies.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1251");

            int userEnter = GetUserInput();
            if (userEnter == 1)
            {
                await ImportDataAsync(host);
                Console.WriteLine("Succefully imported");
                GetUserInput();
            }
            else
            {
                Console.WriteLine("You entered incorrect value");
                GetUserInput();
            }
        }

        static int GetUserInput()
        {
            Console.WriteLine("Press 1 to import currency data");
            if (int.TryParse(Console.ReadLine(), out int userEnter))
            {
                return userEnter;
            }
            return 0;
        }

        static async Task ImportDataAsync(IHost host)
        {
            using var serviceScope = host.Services.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;
            var currencyService = serviceProvider.GetRequiredService<IDataProvider>();
            await currencyService.ImportDataAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddDbContext<CurrenciesContext>(options =>
                {
                    var configuration = new ConfigurationBuilder()
                        .AddJsonFile($"appsettings.json", true, true)
                        .Build();

                    options.UseSqlite(configuration.GetConnectionString("CurrenciesDBConnection"));
                    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    ));
                });

                services.AddTransient<IDataProvider, DataProvider>();
            });
    }
}