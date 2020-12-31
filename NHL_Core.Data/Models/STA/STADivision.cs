using NHL.Data.Attributes;
using NHL.Data.Interfaces;

namespace NHL.Data.Models
{
    [ObjectAnnotation("divisions")]
    public class STADivision : IIdentityNHLModel
    {
        public string Abbreviation { get; set; }
        public bool Active { get; set; }
        public STAConference Conference { get; set; }
        public int Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
    }
}