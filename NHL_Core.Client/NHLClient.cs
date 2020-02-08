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

        public STARequest<Season> GetSeasons()
        {
            return new STARequest<Season>();
        }

        public STARequest<CurrentSeason> GetCurrentSeasonSeason()
        {
            return new STARequest<CurrentSeason>();
        }

        //public LeadersRequest GetLeaders()
        //{
        //    return null;
        //}
    }
}
