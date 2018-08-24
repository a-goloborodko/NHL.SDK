using NHL.Data.Interfaces;
using System;
using System.Collections.Generic;
using NHL.Client.RequestModels;
using System.Linq.Expressions;
using NHL.Data.Model;
using NHL.Client.Resources;
using NHL.Client.ResponseModels;
using System.Reflection;
using System.Linq;

namespace NHL.Client.RequestBuilders
{
    public class GeneralRequestBuilder<TModel, TRequest> : FluentBuilderBase<TModel, TRequest>
        where TModel : INHLModel
    {
        static private MethodInfo _deserializeMethodInfo;

        protected Dictionary<Type, Type> typeBindings;
        protected Type modelType = typeof(TModel);
        protected Dictionary<Type, string> switchRequestUrl;

        static GeneralRequestBuilder()
        {
            _deserializeMethodInfo = typeof(Newtonsoft.Json.JsonConvert).GetMethods(BindingFlags.Public | BindingFlags.Static)
                   .Where(x => x.Name == "DeserializeObject" && x.IsGenericMethod)
                   .Select(x => new { Method = x, Params = x.GetParameters() })
                   .FirstOrDefault(x => x.Params.Length == 1).Method;
        }

        internal GeneralRequestBuilder(IRequestModel requestModel) 
            : base(requestModel)
        {
            typeBindings = new Dictionary<Type, Type> {
             { typeof(Conference), typeof(ConferenceResponseModel) },
             { typeof(Division), typeof(DivisionsResponseModel) },
             { typeof(Franchise), typeof(FranchiseResponseModel) },
             { typeof(Team), typeof(TeamResponseModel) },
             { typeof(Player), typeof(PeopleResponseModel) }};

            switchRequestUrl = new Dictionary<Type, string> {
             { typeof(Conference), ApiUrls.Conferences },
             { typeof(Division), ApiUrls.Divisions },
             { typeof(Franchise), ApiUrls.Franchises },
             { typeof(Team), ApiUrls.Teams },
             { typeof(Player), ApiUrls.People }};
        }

        public GeneralRequestBuilder<TModel, TRequest> SetId<TPropertyType>(Expression<Func<TRequest, TPropertyType>> property, TPropertyType value)
        {
            return (GeneralRequestBuilder<TModel, TRequest>)SetProperty(property, value);
        }

        protected override string GenerateRequestUrl()
        {
            string requestUrl = switchRequestUrl[modelType];

            if (string.IsNullOrWhiteSpace(requestUrl))
            {
                throw new Exception(string.Format("model type {0} not supported.", modelType));
            }

            var requestModel = (GeneralRequestModel)RequestModel;

            if (modelType == typeof(Player) && requestModel.Id == 0)
            {
                throw new ArgumentException("request must include a valid person ID");
            }

            if (requestModel.Id != 0)
            {
                requestUrl += requestModel.Id;
            }

            return requestUrl;
        }

        protected override List<TModel> ParseHttpResult(string httpResponseContent)
        {
            if (string.IsNullOrWhiteSpace(httpResponseContent))
            {
                return new List<TModel>();
            }

            try
            {
                var desserializeObjectType = typeBindings[modelType];

                MethodInfo generic = _deserializeMethodInfo.MakeGenericMethod(desserializeObjectType);
                var response = generic.Invoke(null, new[] { httpResponseContent });

                //TODO: move to automapper
                switch (response)
                {
                    case ConferenceResponseModel conference:
                        return ((ConferenceResponseModel)response).Conferences as List<TModel>;
                    case Division division:
                        return ((DivisionsResponseModel)response).Divisions as List<TModel>;
                    case Team team:
                        return ((TeamResponseModel)response).Teams as List<TModel>;
                    case Player player:
                        return ((PeopleResponseModel)response).People as List<TModel>;
                    case Franchise franchise:
                        return ((FranchiseResponseModel)response).Franchises as List<TModel>;
                    default:
                        throw new Exception($"model type {modelType} not supported.");
                }
            }
            catch (Exception ex)
            {
                return new List<TModel>();
                throw; //TODO: ?????
            }
        }
    }
}
