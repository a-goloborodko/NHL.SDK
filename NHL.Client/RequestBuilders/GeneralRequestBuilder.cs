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
        protected Dictionary<Type, Type> typeBindings;
        protected Type modelType = typeof(TModel);

        internal GeneralRequestBuilder(IRequestModel requestModel) : base(requestModel)
        {
            typeBindings = new Dictionary<Type, Type> {
             { typeof(Conference), typeof(ConferenceResponseModel) },
             { typeof(Division), typeof(DivisionsResponseModel) },
             { typeof(Franchise), typeof(FranchiseResponseModel) },
             { typeof(Team), typeof(TeamResponseModel) },
             { typeof(Player), typeof(PeopleResponseModel) }};
        }

        public GeneralRequestBuilder<TModel, TRequest> SetId<TPropertyType>(Expression<Func<TRequest, TPropertyType>> property, TPropertyType value)
        {
            return (GeneralRequestBuilder<TModel, TRequest>)SetProperty(property, value);
        }

        protected override string GenerateRequestUrl()
        {
            
            var @switch = new Dictionary<Type, string> {
             { typeof(Conference), ApiUrls.Conferences },
             { typeof(Division), ApiUrls.Divisions },
             { typeof(Franchise), ApiUrls.Franchises },
             { typeof(Team), ApiUrls.Teams },
             { typeof(Player), ApiUrls.People }};

            string requestUrl = @switch[modelType];

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
                var method = typeof(Newtonsoft.Json.JsonConvert).GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .Where(x => x.Name == "DeserializeObject" && x.IsGenericMethod)
                    .Select(x => new { Method = x, Params = x.GetParameters() })
                    .FirstOrDefault(x => x.Params.Length == 1).Method;

                var desserializeObjectType = typeBindings[modelType];

                MethodInfo generic = method.MakeGenericMethod(desserializeObjectType);
                var response = generic.Invoke(null, new[] { httpResponseContent });
                if (modelType == typeof(Conference))
                {
                    return ((ConferenceResponseModel)response).Conferences as List<TModel>;
                }
                else if (modelType == typeof(Division))
                {
                    return ((DivisionsResponseModel)response).Divisions as List<TModel>;
                }
                else if (modelType == typeof(Team))
                {
                    return ((TeamResponseModel)response).Teams as List<TModel>;
                }
                else if (modelType == typeof(Player))
                {
                    return ((PeopleResponseModel)response).People as List<TModel>;
                }
                else if (modelType == typeof(Franchise))
                {
                    return ((FranchiseResponseModel)response).Franchises as List<TModel>;
                }
                else
                {
                    throw new Exception(string.Format("model type {0} not supported.", modelType));
                }
            }
            catch (Exception ex)
            {
                return new List<TModel>();
                throw;
            }
        }
    }
}
