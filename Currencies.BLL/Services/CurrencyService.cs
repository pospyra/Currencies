using AutoMapper;
using Currencies.BLL.IServices;
using Currencies.BLL.Services.Abstract;
using Currencies.Common.DTO.Currency;
using Currencies.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Currencies.BLL.Services
{
    public class CurrencyService : BaseService, ICurrencyService
    {
        private readonly IMemoryCache _cache;
        public CurrencyService(CurrenciesContext context, IMapper mapper, IMemoryCache cache) : base(context, mapper)
        {
            _cache = cache;
        }

        public async Task<ICollection<CurrencyDTO>> GetCurrenciesAsync(int pageNumber, int pageSize)
        {
            int skip = (pageNumber - 1) * pageSize;

            var currencies = await _context.Currencies
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            var mappedCurrencies = _mapper.Map<ICollection<CurrencyDTO>>(currencies);

            return mappedCurrencies;
        }

        public async Task<CurrencyDTO> GetCurrencyByIdAsync(string currencyId)
        {
            var currency = await _context.Currencies
                .FirstOrDefaultAsync(x=>x.ID == currencyId);   

            return _mapper.Map<CurrencyDTO>(currency);
        }
    }
}
