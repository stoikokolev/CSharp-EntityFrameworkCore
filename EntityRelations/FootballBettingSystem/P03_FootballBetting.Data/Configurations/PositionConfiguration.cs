using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> entity)
        {
            entity
                .HasKey(p => p.PositionId);

            entity.Property(p => p.Name)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(30);
        }
    }
}