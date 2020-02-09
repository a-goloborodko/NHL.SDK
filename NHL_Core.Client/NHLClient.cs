using NHL.Data.Models;
using NHL_Core.Client.Requests;

namespace NHL_Core.Client
{
    public class NHLClient
    {
        public STAIdRequest<STAConference> GetSTAConferences()
        {
            return new STAIdRequest<STAConference>();
        }

        public STAIdRequest<STADivision> GetSTADivisions()
        {
            return new STAIdRequest<STADivision>();
        }

        public STAIdRequest<STAeam> GetSTATeams()
        {
            return new STAIdRequest<STAeam>();
        }

        public STAIdRequest<STAFranchise> GetSTAFranchises()
        {
            return new STAIdRequest<STAFranchise>();
        }

        public STAPlayersRequest GetSTAPlayer()
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

        public Request<Country> GetCountries()
        {
            return new Request<Country>();
        }

        public FranchisesRequest GetFranchises()
        {
            return new FranchisesRequest();
        }

        public Request<Draft> GetDrafts()
        {
            return new Request<Draft>();
        }
    }
}