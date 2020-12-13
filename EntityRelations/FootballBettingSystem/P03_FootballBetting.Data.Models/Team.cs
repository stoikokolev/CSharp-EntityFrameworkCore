namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public int TeamID { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string Initials { get; set; }

        public decimal Budget { get; set; }

        //TODO: Navigation properties
        public int PrimaryKitColorId { get; set; }

        //TODO: Navigation properties
        public int SecondaryKitColorId { get; set; }

        public int TownId { get; set; }
    }
}