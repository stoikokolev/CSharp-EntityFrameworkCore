using System;
using System.Linq;
using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new FootballBettingContext();

            var users = context
                .Users
                .Select(u => new
                {
                    u.UserName,
                    u.Email,
                    Name = u.Name == null ? "(No name)" : u.Name
                });

            foreach (var user in users)
            {
                Console.WriteLine($"{user.UserName} -> {user.Email} Name: {user.Name}");
            }

        }
    }
}
