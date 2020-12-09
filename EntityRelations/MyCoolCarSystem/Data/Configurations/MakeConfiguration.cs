namespace MyCoolCarSystem.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MakeConfiguration : IEntityTypeConfiguration<Make>
    {
        //One-to-Many relationship
        public void Configure(EntityTypeBuilder<Make> make)
        {
            make
                .HasIndex(m => m.Name)
                .IsUnique();
            make
                .HasMany(m => m.Models)
                .WithOne(m => m.Make)
                .HasForeignKey(m => m.MakeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}