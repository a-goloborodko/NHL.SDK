using NHL.Data.Attributes;
using NHL.Data.Interfaces;

namespace NHL.Data.Model
{
    [ObjectAnnotation("people")]
    public class Player : INHLModel
    {
        public bool Active { get; set; }
        public bool AlternateCaptain { get; set; }
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }
        public string BirthDate { get; set; }
        public bool Captain { get; set; }
        public int CurrentAge { get; set; }
        public Team CurrentTeam { get; set; }
        public long TeamId { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string Height { get; set; }
        public int Id { get; set; }
        public string Weight { get; set; }
        public string Link { get; set; }
        public string Nationality { get; set; }
        public int PrimaryNumber { get; set; }
        public bool Rookie { get; set; }
        public string RosterStatus { get; set; }
        public string ShootsCatches { get; set; }
        public Position PrimaryPosition { get; set; }

        //TODO: create enums for Position (Type = Forward...)
    }
}
