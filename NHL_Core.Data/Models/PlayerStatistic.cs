using NHL.Data.Interfaces;

namespace NHL.Data.Models
{
    public class PlayerStatistic : INHLModel
    {
        public long PlayerId { get; set; }
        public long SeasonId { get; set; }
        public int Assists { get; set; }
        public decimal FaceoffWinPctg { get; set; }
        public int GamesPlayed { get; set; }
        public int GameWinningGoals { get; set; }
        public int Goals { get; set; }
        public int OtGoals { get; set; }
        public int PenaltyMinutes { get; set; }
        public int PlusMinus { get; set; }
        public int Points { get; set; }
        public int PpGoals { get; set; }
        public int PpPoints { get; set; }
        public int ShGoals { get; set; }
        public int ShPoints { get; set; }
        public decimal ShiftsPerGame { get; set; }
        public decimal ShootingPctg { get; set; }
        public int Shots { get; set; }
        public decimal TimeOnIcePerGame { get; set; }
        public double PointsPerGame { get; set; }
        public string PlayerBirthCity { get; set; }
        public string PlayerBirthCountry { get; set; }
        public string PlayerBirthDate { get; set; }
        public string PlayerBirthStateProvince { get; set; }
        public string PlayerDraftOverallPickNo { get; set; }
        public string PlayerDraftRoundNo { get; set; }
        public string PlayerDraftYear { get; set; }
        public string PlayerFirstName  { get; set; }
        public string PlayerLastName { get; set; }
        public string PlayerHeight { get; set; }
        public string PlayerWeight { get; set; }
        public string PlayerInHockeyHof { get; set; }
        public int PlayerIsActive { get; set; }
        public string PlayerNationality { get; set; }
        public string PlayerPositionCode { get; set; }
        public string PlayerShootsCatches { get; set; }
        public string PlayerTeamsPlayedFor { get; set; }
    }
}
