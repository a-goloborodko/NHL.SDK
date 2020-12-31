using NHL_Core.Client.Attributes;

namespace NHL_Core.Client.ExtendModels
{
    public class FranchiseModel
    {
        [RequestQueryParameterName("firstSeason.id")]
        public object FirstSeasonId { get; set; }

        [RequestQueryParameterName("lastSeason.id")]
        public object LastSeasonId { get; set; }
    }
}