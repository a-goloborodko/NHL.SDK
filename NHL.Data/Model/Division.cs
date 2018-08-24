using NHL.Data.Attributes;
using NHL.Data.Interfaces;

namespace NHL.Data.Model
{
    [ObjectAnnotation("divisions")]
    public class Division : INHLModel
    {
        public string Abbreviation { get; set; }
        public bool Active { get; set; }
        public Conference Conference { get; set; }
        public int Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
    }
}