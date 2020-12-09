namespace MyCoolCarSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Make> Makes { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CarPurchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseSqlServer(DataSettings.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder
                .Entity<Model>()
                .HasIndex(m => m.Name)
                .IsUnique();

           
            builder
                .Entity<Make>(make =>
                {
                    make
                        .HasIndex(m => m.Name)
                        .IsUnique();
                    make
                        .HasMany(m => m.Models)
                        .WithOne(m => m.Make)
                        .HasForeignKey(m => m.MakeId)
                        .OnDelete(DeleteBehavior.Restrict);

                });
            
            builder
                .Entity<Car>(car =>
                {
                    car.HasIndex(m => m.Vin)
                        .IsUnique();
                    car

                        .HasOne(c => c.Model)
                        .WithMany(m => m.Cars)
                        .HasForeignKey(c => c.ModelId);
                });

            builder
                .Entity<CarPurchase>(purchase =>
                {
                    purchase.HasKey(p => new
                    {
                        p.CustomerId, p.CarId
                    });

                    purchase
                        .HasOne(p => p.Customer)
                        .WithMany(c => c.Purchases)
                        .HasForeignKey(p => p.CustomerId)
                        .OnDelete(DeleteBehavior.Restrict);

                    purchase
                        .HasOne(c => c.Car)
                        .WithMany(c => c.Owners)
                        .HasForeignKey(p => p.CarId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
        }
    }
}