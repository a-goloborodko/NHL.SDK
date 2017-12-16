using NHL.Client.RequestBuilders;
using NHL.Client.RequestModels;
using NHL.Data.Model;

namespace NHL.Client
{
    public class NHLClient
    {
        public GeneralRequestBuilder<Conference, GeneralRequestModel> GetConferences()
        {
            return new GeneralRequestBuilder<Conference, GeneralRequestModel>(new GeneralRequestModel());
        }

        public GeneralRequestBuilder<Division, GeneralRequestModel> GetDivisions()
        {
            return new GeneralRequestBuilder<Division, GeneralRequestModel>(new GeneralRequestModel());
        }

        public GeneralRequestBuilder<Team, GeneralRequestModel> GetTeams()
        {
            return new GeneralRequestBuilder<Team, GeneralRequestModel>(new GeneralRequestModel());
        }

        public GeneralRequestBuilder<Franchise, GeneralRequestModel> GetFranchises()
        {
            return new GeneralRequestBuilder<Franchise, GeneralRequestModel>(new GeneralRequestModel());
        }

        public GeneralRequestBuilder<Player, GeneralRequestModel> GetPlayer()
        {
            return new GeneralRequestBuilder<Player, GeneralRequestModel>(new GeneralRequestModel());
        }
    }
}
