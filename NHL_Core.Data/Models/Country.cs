using NHL.Data.Interfaces;

namespace NHL.Data.Models
{
    public class Country : INHLModel
    {
        public string Id { get; set; }
        public string Country3Code { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public bool HasPlayerStats { get; set; }
        public string ImageUrl { get; set; }
        public string IocCode { get; set; }
        public bool IsActive { get; set; }
        public string NationalityName { get; set; }
        public string OlympicUrl { get; set; }
        //public object[] StateProvinces { get; set; } // TODO: check later if NHL added info for this property
        public string ThumbnailUrl { get; set; }
    }
}
