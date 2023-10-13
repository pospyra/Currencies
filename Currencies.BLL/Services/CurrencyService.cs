using AutoMapper;
using Currencies.BLL.IServices;
using Currencies.Common.DTO;
using Currencies.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Currencies.BLL.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly CurrenciesContext _context;
        private readonly IMapper _mapper;
        public CurrencyService(CurrenciesContext context, IMapper mapper) 
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ICollection<CurrencyDTO>> GetCurrenciesAsync()
        {
            var currenies = await _context.Valutes.ToListAsync();

            return _mapper.Map<ICollection<CurrencyDTO>>(currenies);
        }

        public async Task<CurrencyDTO> GetCurrencyByIdAsync(string currencyId)
        {
            var currency = await _context.Valutes.FirstOrDefaultAsync(x=>x.ID == currencyId);   
            return _mapper.Map<CurrencyDTO>(currency);
        }
    }
}
