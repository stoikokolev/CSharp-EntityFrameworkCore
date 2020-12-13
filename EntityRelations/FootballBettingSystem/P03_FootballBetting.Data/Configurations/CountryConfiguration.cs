using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity
                .HasKey(c => c.CountryId);

            entity
                .Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);
        }
    }
}