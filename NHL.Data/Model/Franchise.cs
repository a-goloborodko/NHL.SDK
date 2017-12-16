using NHL.Data.Enums;
using NHL.Data.Interfaces;

namespace NHL.Data.Model
{
    public class Franchise : INHLModel
    {
        public SeasonEnum FirstSeasonId { get; set; }
        public int FranchiseId { get; set; }
        public string Link { get; set; }
        public string LocationName { get; set; }
        public int MostRecentTeamId { get; set; }
        public string TeamName { get; set; }
    }
}