using NHL.Data.Interfaces;

namespace NHL.Data.Model.Leaders
{
    public class Leader : INHLModel
    {
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string TeamFullName { get; set; }
        public string TeamLogoURL { get; set; }
        public int ListIndex { get; set; }
        public int TeamId { get; set; }
        public int WweaterNumber { get; set; }
        public int PlayerId { get; set; }
        public double Value { get; set; }
        public string Tricode { get; set; }
    }
}