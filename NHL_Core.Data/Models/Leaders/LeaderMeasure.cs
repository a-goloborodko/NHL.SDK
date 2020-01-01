using NHL.Data.Interfaces;
using System.Collections.Generic;

namespace NHL.Data.Models.Leaders
{
    public class LeaderMeasure : INHLModel
    {
        public LeaderMeasure()
        {
            Leaders = new List<Leader>();
        }

        public string Measure { get; set; }
        public string LeagueAverage { get; set; }
        public List<Leader> Leaders { get; set; }
    }
}