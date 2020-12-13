using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configuratons
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity
                        .HasKey(u => u.UserId);

            entity
                .Property(u => u.UserName)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

            entity
                .Property(u => u.Password)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(256);

            entity
                .Property(u => u.Email)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

            entity
                .Property(u => u.Name)
                .IsRequired(false)
                .IsUnicode(true)
                .HasMaxLength(80);

        }
    }
}