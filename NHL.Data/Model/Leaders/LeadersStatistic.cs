using NHL.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace NHL.Data.Model.Leaders
{
    public class LeadersStatistic : INHLModel
    {
        public LeadersStatistic()
        {
            Goalie = new List<LeaderMeasure>();
            Skater = new List<LeaderMeasure>();
        }

        public List<LeaderMeasure> Goalie { get; set; }
        public List<LeaderMeasure> Skater { get; set; }
    }
}