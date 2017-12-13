using NHL.Data.Enums;

namespace NHL.Data.Model
{
    public class Franchise
    {
        public SeasonEnum FirstSeasonId { get; set; }
        public int FranchiseId { get; set; }
        public string Link { get; set; }
        public string LocationName { get; set; }
        public int MostRecentTeamId { get; set; }
        public string TeamName { get; set; }
    }
}