using NHL.Client.Requests;
using NHL.Data.Model;

namespace NHL.Client
{
    public class NHLClient
    {
        public GeneralRequest<Conference> GetConferences()
        {
            return new GeneralRequest<Conference>();
        }

        public GeneralRequest<Division> GetDivisions()
        {
            return new GeneralRequest<Division>();
        }

        public GeneralRequest<Team> GetTeams()
        {
            return new GeneralRequest<Team>();
        }

        public GeneralRequest<Franchise> GetFranchises()
        {
            return new GeneralRequest<Franchise>();
        }

        public GeneralRequest<Player> GetPlayer()
        {
            return new GeneralRequest<Player>();
        }

        public LeadersRequest GetLeaders()
        {
            return new LeadersRequest();
        }
    }
}
