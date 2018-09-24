using NHL.Client.RequestHandlers;
using NHL.Client.RequestModels;
using NHL.Data.Enums;
using NHL.Data.Model.Leaders;

namespace NHL.Client.Requests
{
    public sealed class LeadersRequest : RequestBase<LeadersStatistic, LeadersRequestModel>
    {
        internal LeadersRequest()
            : base(new LeadersRequestHandler())
        { }

        public void SetSeason(SeasonEnum season)
        {
            FluentBuilder.SetProperty((prop)=> prop.Season, season);
        }

        public void SetGameType(GameTypeEnum gameType)
        {
            FluentBuilder.SetProperty((prop) => prop.GameType, gameType);
        }

        public void SetTeam(TeamEnum team)
        {
            FluentBuilder.SetProperty((prop) => prop.Team, team);
        }
    }
}