using NHL.Data.Enums;
using NHL.Data.Helpers;

namespace NHL.Client.RequestModels
{
    public class LeadersRequestModel : IRequestModel
    {
        public GameTypeEnum GameType { get; set; }
        public SeasonEnum Season { get; set; }
        public TeamEnum Team { get; set; }

        public LeadersRequestModel()
        {
            Season = SeasonHelper.GetCurrectSeason();
            GameType = GameTypeEnum.RegularSeason;
            Team = TeamEnum.ALL;
        }
    }
}