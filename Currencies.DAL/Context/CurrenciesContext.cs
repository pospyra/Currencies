using Currencies.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Currencies.DAL.Context
{
    public class CurrenciesContext : DbContext
    {
        public CurrenciesContext() { }

        public CurrenciesContext(DbContextOptions<CurrenciesContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ValCurs> ValCurs { get; set; }
    }
}
