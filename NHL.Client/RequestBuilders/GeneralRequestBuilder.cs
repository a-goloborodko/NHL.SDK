using NHL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHL.Client.RequestModels;
using System.Linq.Expressions;
using NHL.Data.Model;
using NHL.Client.Resources;

namespace NHL.Client.RequestBuilders
{
    public class GeneralRequestBuilder<T> : FluentBuilderBase<T>
        where T : INHLModel
    {
        internal GeneralRequestBuilder(IRequestModel requestModel) : base(requestModel)
        { }

        public GeneralRequestBuilder<T> SetId<TPropertyType>(Expression<Func<T, TPropertyType>> property, TPropertyType value)
        {
            return (GeneralRequestBuilder<T>)SetProperty(property, value);
        }

        protected override string GenerateRequestUrl()
        {
            var modelType = typeof(T);
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

            if (requestModel.Id != 0)
            {
                requestUrl += requestModel.Id;
            }

            return requestUrl;
        }

        protected override List<T> ParseHttpResult(string httpResponseContent)
        {
            return new List<T>();
        }
    }
}
