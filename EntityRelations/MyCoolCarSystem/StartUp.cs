using Microsoft.EntityFrameworkCore;
using MyCoolCarSystem.Data;

namespace MyCoolCarSystem
{

    public class StartUp
    {
        public static void Main()
        {
            using var db = new CarDbContext();

            db.Database.Migrate();

            //enter your queries here

            db.SaveChanges();

        }
    }
}
