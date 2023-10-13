using Currencies.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Currencies.DAL.EntityConfigurations
{
    public class ValCursConfiguration : IEntityTypeConfiguration<ValCurs>
    {
        public void Configure(EntityTypeBuilder<ValCurs> builder)
        {
            builder.Property(e => e.Id)
             .ValueGeneratedOnAdd();

            builder.HasMany(vc => vc.Valutes)
                .WithOne(v => v.ValCurs)
                .HasForeignKey(v => v.ValCursId);
        }
    }
}
