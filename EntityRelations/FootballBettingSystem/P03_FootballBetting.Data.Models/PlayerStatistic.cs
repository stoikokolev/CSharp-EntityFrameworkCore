namespace P03_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        //TODO: Composite PK
        public int GameId { get; set; }
        public Game Game { get; set; }

        //TODO: Composite PK
        public int PlayerID { get; set; }
        public Player Player { get; set; }

        public byte ScoredGoals { get; set; }

        public byte Assists { get; set; }

        public byte MinutesPlayed { get; set; }
    }
}