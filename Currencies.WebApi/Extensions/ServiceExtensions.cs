using Currencies.BLL.IServices;
using Currencies.BLL.Services;

namespace Currencies.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterCustomService(this IServiceCollection services)
        {
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
