using Currencies.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Currencies.WebApi.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCurrencyContext(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            using var context = scope?.ServiceProvider.GetRequiredService<CurrenciesContext>();
            context?.Database.Migrate();
        }
    }
}
