using AutoMapper;
using Currencies.BLL.IServices;
using Currencies.BLL.Services.Abstract;
using Currencies.BLL.Services.Helpers;
using Currencies.Common.DTO.User;
using Currencies.DAL.Context;
using Currencies.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Currencies.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IConfiguration _configuration;
        public UserService(CurrenciesContext context, IMapper mapper, IConfiguration configuration) : base(context, mapper) 
        {
            _configuration = configuration;
        }

        public async Task<UserDto> CreateUser(NewUserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);

            var salt = SecurityHelper.GetRandomBytes();

            userEntity.Salt = Convert.ToBase64String(salt);
            userEntity.Password = SecurityHelper.HashPassword(userDto.Password, salt);

            _context.Users.Add(userEntity);
             await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<string> Login(LoginUserDto userLogin)
        {
            var userEntity = await _context.Users
                .FirstOrDefaultAsync(user => user.Email == userLogin.Email) 
                    ?? throw new InvalidOperationException($"The user already exist");

            if (!SecurityHelper.ValidatePassword(userLogin.Password, userEntity.Password, userEntity.Salt))
            {
                throw new ArgumentException($"Invalid password or email");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userEntity.Id.ToString()),
                new Claim(ClaimTypes.Name, userEntity.UserName),
                new Claim(ClaimTypes.Email, userEntity.Email)
            };

            string secretKey = _configuration["Token:SecretJWTKey"];

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    SecurityAlgorithms.HmacSha256
                    )
                );

            var authToken = new JwtSecurityTokenHandler().WriteToken(token);

            return authToken;
        }
    }
}
