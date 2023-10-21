using Currencies.BLL.IServices;
using Currencies.BLL.Services;
using Currencies.Common.DTO.Currency;
using Currencies.Common.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Currencies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<ICollection<CurrencyDTO>>> Registration(NewUserDto newUser)
        {
            var result = await _userService.CreateUser(newUser);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ICollection<CurrencyDTO>>> Login(LoginUserDto user)
        {
            var result = await _userService.Login(user);
            return Ok(result);
        }
    }
}
