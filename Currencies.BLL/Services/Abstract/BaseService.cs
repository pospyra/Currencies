using AutoMapper;
using Currencies.DAL.Context;

namespace Currencies.BLL.Services.Abstract
{
    public abstract class BaseService
    {
        private protected readonly CurrenciesContext _context;
        private protected readonly IMapper _mapper;

        public BaseService(CurrenciesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
