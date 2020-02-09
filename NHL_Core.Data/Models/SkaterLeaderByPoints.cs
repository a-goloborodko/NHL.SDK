using NHL.Data.Interfaces;

namespace NHL.Data.Models
{
    public class SkaterLeaderByPoints : INHLModel
    {
        public Player Player { get; set; }
        public int Points { get; set; }
        public Team Team { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public int? CurrentTeamId { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string PositionCode { get; set; }
        public int SweaterNumber { get; set; }
    }

    public class Team
    {
        public int Id { get; set; }
        public int FranchiseId { get; set; }
        public string FullName { get; set; }
        public int LeagueId { get; set; }
        public Logo[] Logos { get; set; }
        public string RawTricode { get; set; }
        public string TriCode { get; set; }
    }

    public class Logo
    {
        public int Id { get; set; }
        public string Background { get; set; }
        public int EndSeason { get; set; }
        public string SecureUrl { get; set; }
        public int StartSeason { get; set; }
        public int TeamId { get; set; }
        public string Url { get; set; }
    }
}
