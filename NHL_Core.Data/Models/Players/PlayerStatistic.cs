namespace NHL.Data.Models
{
    public class PlayerStatistic
    {
        public StatisticType Type { get; set; }
        public Split[] Splits { get; set; }
    }

    public class StatisticType
    {
        public string DisplayName { get; set; }
    }

    public class Split
    {
        //TODO: use Season enum. Add JsonConverter
        public string Season { get; set; }
        public Stat Stat { get; set; }
        public Team Team { get; set; }
        public League League { get; set; }
        public int SequenceNumber { get; set; }
    }

    public class Stat
    {
        public string TimeOnIce { get; set; }
        public int Assists { get; set; }
        public int Goals { get; set; }
        public int Pim { get; set; }
        public int Games { get; set; }
        public string PowerPlayTimeOnIce { get; set; }
        public string EvenTimeOnIce { get; set; }
        public string PenaltyMinutes { get; set; }
        public float FaceOffPct { get; set; }
        public string ShortHandedTimeOnIce { get; set; }
        public int Points { get; set; }
        public int Shifts { get; set; }
        public int Shots { get; set; }
        public int Hits { get; set; }
        public int PowerPlayGoals { get; set; }
        public int PowerPlayPoints { get; set; }
        public float ShotPct { get; set; }
        public int GameWinningGoals { get; set; }
        public int OverTimeGoals { get; set; }
        public int ShortHandedGoals { get; set; }
        public int ShortHandedPoints { get; set; }
        public int Blocked { get; set; }
        public int PlusMinus { get; set; }
        public string TimeOnIcePerGame { get; set; }
        public string EvenTimeOnIcePerGame { get; set; }
        public string ShortHandedTimeOnIcePerGame { get; set; }
        public string PowerPlayTimeOnIcePerGame { get; set; }
    }
}
