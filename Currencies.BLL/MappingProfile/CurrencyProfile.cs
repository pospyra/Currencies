using AutoMapper;
using Currencies.Common.DTO;
using Currencies.DAL.Entities;

namespace Currencies.BLL.MappingProfile
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        { 
            CreateMap<Valute, CurrencyDTO>().ReverseMap();
        }
    }
}
