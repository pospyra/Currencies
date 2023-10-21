using AutoMapper;
using Currencies.Common.DTO.Currency;
using Currencies.DAL.Entities;

namespace Currencies.BLL.MappingProfile
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        { 
            CreateMap<Currency, CurrencyDTO>().ReverseMap();
        }
    }
}
