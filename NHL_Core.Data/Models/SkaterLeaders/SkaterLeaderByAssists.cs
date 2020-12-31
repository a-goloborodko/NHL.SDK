using NHL.Data.Interfaces;

namespace NHL.Data.Models
{
    public class SkaterLeaderByAssists: ISkaterLeaderModel
    {
        public int Assists { get; set; }
        public Player Player { get; set; }
        public Team Team { get; set; }
    }
}