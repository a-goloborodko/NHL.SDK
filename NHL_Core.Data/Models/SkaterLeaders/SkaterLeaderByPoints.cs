using NHL.Data.Interfaces;

namespace NHL.Data.Models
{
    public class SkaterLeaderByPoints : ISkaterLeaderModel
    {
        public Player Player { get; set; }
        public int Points { get; set; }
        public Team Team { get; set; }
    }
}
