using NHL.Data.Interfaces;

namespace NHL.Data.Models
{
    public class Draft : INHLModel
    {
        public int Id { get; set; }
        public int DraftYear { get; set; }
        public int Rounds { get; set; }
    }
}