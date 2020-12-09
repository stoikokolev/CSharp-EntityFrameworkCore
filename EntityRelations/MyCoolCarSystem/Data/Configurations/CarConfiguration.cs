namespace MyCoolCarSystem.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        //Many-to-One relationship
        public void Configure(EntityTypeBuilder<Car> car)
        {
            car.HasIndex(m => m.Vin)
                .IsUnique();
            car

                .HasOne(c => c.Model)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.ModelId);
        }
    }
}