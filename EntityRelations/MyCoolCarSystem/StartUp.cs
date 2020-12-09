using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyCoolCarSystem.Data;
using MyCoolCarSystem.Results;

namespace MyCoolCarSystem
{

    public class StartUp
    {
        public static void Main()
        {
            using var db = new CarDbContext();

            db.Database.Migrate();

            var purchases = db
                .Purchases
                .Select(p => new PurchaseResultModel
                {
                    Price = p.Price,
                    PurchaseDate = p.PurchaseDate,
                    Customer = new CustomerResultModel()
                    {
                        Name = p.Customer.FirstName + " " + p.Customer.LastName,
                        Town = p.Customer.Address.Town
                    },
                    Car = new CarResultModel
                    {
                        Vin = p.Car.Vin,
                        Make = p.Car.Model.Make.Name,
                        Model = p.Car.Model.Name
                    },

                })
                .ToList();



            db.SaveChanges();

        }
    }
}
