using AutoMapper;
using Currencies.BLL.IServices;
using Currencies.BLL.Services.Abstract;
using Currencies.Common.DTO.Currency;
using Currencies.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Currencies.BLL.Services
{
    public class CurrencyService : BaseService,ICurrencyService
    {
        private readonly IMemoryCache _cache;
        public CurrencyService(CurrenciesContext context, IMapper mapper, IMemoryCache cache) : base(context, mapper)
        {
            _cache = cache;
        }

        public async Task<ICollection<CurrencyDTO>> GetCurrenciesAsync()
        {
            if (_cache.TryGetValue("Currencies", out ICollection<CurrencyDTO> cachedCurrencies))
            {
                if (cachedCurrencies is not null)
                {
                    return cachedCurrencies;  
                }
            }

            var currencies = await _context.Currencies.ToListAsync();
            var mappedCurrencies = _mapper.Map<ICollection<CurrencyDTO>>(currencies);

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };

            if (mappedCurrencies.Any())
            {
                _cache.Set("Currencies", mappedCurrencies, cacheOptions);
            }

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
