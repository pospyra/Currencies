using AutoMapper;
using Currencies.Common.DTO.User;
using Currencies.DAL.Entities;

namespace Currencies.BLL.MappingProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<NewUserDto, User>();
            CreateMap<LoginUserDto, User>();
        }
    }
}
