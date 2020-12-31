namespace NHL.Data.Models
{
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
}
