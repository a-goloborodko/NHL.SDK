using NHL.Data.Models;
using NHL_Core.Client.Requests;

namespace NHL_Core.Client
{
    public class NHLClient
    {
        public Request<Conference> GetConferences()
        {
            return new Request<Conference>();
        }

        public Request<Division> GetDivisions()
        {
            return new Request<Division>();
        }

        public Request<Team> GetTeams()
        {
            return new Request<Team>();
        }

        public Request<Franchise> GetFranchises()
        {
            return new Request<Franchise>();
        }

        public Request<Player> GetPlayer()
        {
            return new Request<Player>();
        }

        //public LeadersRequest GetLeaders()
        //{
        //    return null;
        //}
    }
}
