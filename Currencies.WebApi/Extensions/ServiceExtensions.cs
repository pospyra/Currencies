using Currencies.BLL.IServices;
using Currencies.BLL.MappingProfile;
using Currencies.BLL.Services;
using Currencies.DAL.Context;

namespace Currencies.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterCustomService(this IServiceCollection services)
        {
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IUserService, UserService>();
            services.AddDbContext<CurrenciesContext>();
            services.AddAutoMapper(typeof(CurrencyProfile));
        }
    }
}
