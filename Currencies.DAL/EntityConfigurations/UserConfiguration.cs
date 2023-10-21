using Currencies.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Currencies.DAL.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id)
             .ValueGeneratedOnAdd();

            builder.HasIndex(e => e.Email)
                .IsUnique();
        }
    }
}
