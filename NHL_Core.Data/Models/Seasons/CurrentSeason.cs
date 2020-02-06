using Newtonsoft.Json;
using NHL.Data.Attributes;
using NHL.Data.Enums;
using NHL.Data.Interfaces;

namespace NHL.Data.Models
{
    [ObjectAnnotation("data")]
    public class CurrentSeason : INHLModel
    {
        [JsonProperty("id")]
        public string Type { get; set; }

        public GameTypeEnum GameType { get; set; }

        [JsonProperty("Season")]
        public SeasonEnum Id { get; set; }
    }
}
