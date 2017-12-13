namespace NHL.Data.Model
{
    public class Team
    {
        public string Abbreviation { get; set; }
        public bool Active { get; set; }
        public Conference Conference { get; set; }
        public Division Division { get; set; }
        public int FirstYearOfPlay { get; set; }
        public Franchise Franchise { get; set; }
        public int FranchiseId { get; set; }
        public string OfficialSiteUrl  { get; set; }
        public string ShortName { get; set; }
        public int Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public Venue Venue { get; set; }
    }
}
