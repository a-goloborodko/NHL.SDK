using NHL.Data.Models;
using NHL_Core.Client.Requests;

namespace NHL_Core.Client
{
    public class NHLClient
    {
        public IdRequest<Conference> GetConferences()
        {
            return new IdRequest<Conference>();
        }

        public IdRequest<Division> GetDivisions()
        {
            return new IdRequest<Division>();
        }

        public IdRequest<Team> GetTeams()
        {
            return new IdRequest<Team>();
        }

        public IdRequest<Franchise> GetFranchises()
        {
            return new IdRequest<Franchise>();
        }

        public PlayersRequest GetPlayer()
        {
            return new PlayersRequest();
        }

        //public LeadersRequest GetLeaders()
        //{
        //    return null;
        //}
    }
}
