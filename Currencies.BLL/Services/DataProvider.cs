using Currencies.DAL.Context;
using Currencies.DAL.Entities;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Currencies.BLL.Services
{
    public class DataProvider
    {

        private static readonly HttpClient httpClient = new();
        private readonly string baseUrl = "http://www.cbr.ru/scripts/XML_daily.asp";

        private readonly CurrenciesContext _context;
        public DataProvider(CurrenciesContext context)
        {
            _context = context;
        }

        public async Task ImportDataAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            var xmlData = XDocument.Parse(responseBody);

            if (xmlData is not null)
            {
                XmlSerializer serializer = new(typeof(ValCurs));

                using var reader = xmlData.Root!.CreateReader();
                ValCurs? valCurs = serializer.Deserialize(reader) as ValCurs;

                if (valCurs is not null)
                {
                    await _context.ValCurs.AddAsync(valCurs);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}