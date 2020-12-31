using NHL.Data.Enums;
using NHL.Data.Interfaces;

namespace NHL.Data.Models
{
    public class Franchise : INHLModel
    {
        public int Id { get; set; }
        public SeasonId FirstSeason { get; set; }
        public string FullName { get; set; }
        public SeasonId LastSeason { get; set; }
        public string TeamCommonName { get; set; }
        public string TeamPlaceName { get; set; }
    }

    public class SeasonId
    {
        public SeasonEnum Id { get; set; }
    }
}