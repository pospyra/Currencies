using Currencies.BLL.Services;
using Currencies.DAL.Context;
using System.Text;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1251");

            await UpdateDatabase();
        }

        private static async Task UpdateDatabase()
        {
            Console.WriteLine("Enter 1 if you want update a data.");
            int userEnter = int.Parse(Console.ReadLine());
            if (userEnter == 1)
            {
                var context = new CurrenciesContext();
                var dataProvider = new DataProvider(context);
                await dataProvider.ImportDataAsync();
            }
            else
            {
                Console.WriteLine("You entered incorrect value");
                await UpdateDatabase();
            }
        }
    }
}