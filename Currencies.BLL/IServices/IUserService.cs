using Currencies.Common.DTO.User;

namespace Currencies.BLL.IServices
{
    public interface IUserService
    {
        public Task<UserDto> CreateUser(NewUserDto userDto);
        public Task<string> Login(LoginUserDto userLogin);
    }
}
