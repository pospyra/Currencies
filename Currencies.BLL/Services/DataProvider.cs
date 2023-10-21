using Currencies.BLL.IServices;
using Currencies.DAL.Context;
using Currencies.DAL.Entities;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Currencies.BLL.Services
{
    public class DataProvider : IDataProvider
    {
        private static readonly HttpClient httpClient = new();
        private readonly string url = "http://www.cbr.ru/scripts/XML_daily.asp";

        private readonly CurrenciesContext _context;
        public DataProvider(CurrenciesContext context)
        {
            _context = context;
        }


        public async Task ImportDataAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            var xmlData = XDocument.Parse(responseBody);

            if (xmlData is not null)
            {
                XmlSerializer serializer = new(typeof(ValCurs));

                using var reader = xmlData.Root.CreateReader();
                ValCurs valCurs = serializer.Deserialize(reader) as ValCurs;

                if (valCurs is not null)
                {
                    if (_context.ValCurs.Any())
                    {
                        _context.ValCurs.Update(valCurs);
                    }
                    else
                    {
                        await _context.ValCurs.AddAsync(valCurs);
                    }

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}