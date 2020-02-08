using NHL.Data.Attributes;
using NHL.Data.Interfaces;

namespace NHL.Data.Models
{
    [ObjectAnnotation("teams")]
    public class STAeam : IIdentityNHLModel
    {
        public string Abbreviation { get; set; }
        public bool Active { get; set; }
        public STAConference Conference { get; set; }
        public STADivision Division { get; set; }
        public int FirstYearOfPlay { get; set; }
        public Franchise Franchise { get; set; }
        public int FranchiseId { get; set; }
        public string OfficialSiteUrl  { get; set; }
        public string ShortName { get; set; }
        public int Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public STAVenue Venue { get; set; }
    }
}
