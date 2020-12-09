using System;
using System.Linq;
using System.Reflection;
using MyCoolCarSystem.Data.Configurations;

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

        public DbSet<Address> Addresses { get; set; }

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
            /*


            //One-to-One relationship
            builder.ApplyConfiguration(new CustomerConfiguration());

            builder.ApplyConfiguration(new ModelConfiguration());

            //One-to-Many relationship
            builder.ApplyConfiguration(new MakeConfiguration());

            //Many-to-One relationship
            builder.ApplyConfiguration(new CarConfiguration());

            //Many-to-Many relationship
            builder.ApplyConfiguration(new CarPurchaseConfiguration());

            */

            //with reflection we don't need to use commented code above
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
    }
}