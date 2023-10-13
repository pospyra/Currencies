using Currencies.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Currencies.DAL.Context
{
    public class CurrenciesContext : DbContext
    {
        public CurrenciesContext() { }

        public CurrenciesContext(DbContextOptions<CurrenciesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Valute> Valutes { get; set; }
        public DbSet<ValCurs> ValCurs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source=currencies.db");
            }
        }
    }
}
