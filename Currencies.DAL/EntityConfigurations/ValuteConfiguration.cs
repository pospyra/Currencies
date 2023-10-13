using Currencies.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Currencies.DAL.EntityConfigurations
{
    public class ValuteConfiguration : IEntityTypeConfiguration<Valute>
    {
        public void Configure(EntityTypeBuilder<Valute> builder)
        {
            builder.Property(e => e.ID)
             .ValueGeneratedOnAdd();
        }
    }
}
