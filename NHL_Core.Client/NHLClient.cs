using NHL.Data.Models;
using NHL_Core.Client.Requests;

namespace NHL_Core.Client
{
    public class NHLClient
    {
        public STAIdRequest<STAConference> GetConferences()
        {
            return new STAIdRequest<STAConference>();
        }

        public STAIdRequest<STADivision> GetDivisions()
        {
            return new STAIdRequest<STADivision>();
        }

        public STAIdRequest<STAeam> GetTeams()
        {
            return new STAIdRequest<STAeam>();
        }

        public STAIdRequest<Franchise> GetFranchises()
        {
            return new STAIdRequest<Franchise>();
        }

        public STAPlayersRequest GetPlayer()
        {
            return new STAPlayersRequest();
        }

        public Request<Season> GetSeasons()
        {
            return new Request<Season>();
        }

        public Request<CurrentSeason> GetCurrentSeasonSeason()
        {
            return new Request<CurrentSeason>();
        }

        //public LeadersRequest GetLeaders()
        //{
        //    return null;
        //}
    }
}
