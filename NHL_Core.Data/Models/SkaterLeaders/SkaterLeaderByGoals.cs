using NHL.Data.Interfaces;

namespace NHL.Data.Models
{
    public class SkaterLeaderByGoals : ISkaterLeaderModel
    {
        public int Goals { get; set; }
        public Player Player { get; set; }
        public Team Team { get; set; }
    }
}