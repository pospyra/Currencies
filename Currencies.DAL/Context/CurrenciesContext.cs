using Currencies.DAL.Entities;
using Currencies.DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Currencies.DAL.Context
{
    public class CurrenciesContext : DbContext
    {
        public CurrenciesContext() { }

        public CurrenciesContext(DbContextOptions<CurrenciesContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
