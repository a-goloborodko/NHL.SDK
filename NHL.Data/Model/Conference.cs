using NHL.Data.Interfaces;

namespace NHL.Data.Model
{
    public class Conference : INHLModel
    {
        public string Abbreviation { get; set; }
        public bool Active { get; set; }
        public int Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}