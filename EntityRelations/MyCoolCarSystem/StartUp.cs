using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using MyCoolCarSystem.Data.Models;
using MyCoolCarSystem.Data;

namespace MyCoolCarSystem
{

    public class StartUp
    {
        public static void Main()
        {
            using var db = new CarDbContext();

            db.Database.Migrate();

            var car = db.Cars.FirstOrDefault();

            var customer = new Customer
            {
                FirstName = "Ivan",
                LastName = "Peshov",
                Age = 29
            };

            customer.Purchases.Add(new CarPurchase
            {
                Car = car,
                PurchaseDate = DateTime.Now.AddDays(-10),
                Price = car.Price*0.9m
            });

            db.Customers.Add(customer);


            db.SaveChanges();

        }
    }
}
