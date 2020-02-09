namespace NHL.Data.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int? CurrentTeamId { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string PositionCode { get; set; }
        public int SweaterNumber { get; set; }
    }
}
