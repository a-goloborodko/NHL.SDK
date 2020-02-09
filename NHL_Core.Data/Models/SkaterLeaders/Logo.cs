namespace NHL.Data.Models
{
    public class Logo
    {
        public int Id { get; set; }
        public string Background { get; set; }
        public int EndSeason { get; set; }
        public string SecureUrl { get; set; }
        public int StartSeason { get; set; }
        public int TeamId { get; set; }
        public string Url { get; set; }
    }
}
