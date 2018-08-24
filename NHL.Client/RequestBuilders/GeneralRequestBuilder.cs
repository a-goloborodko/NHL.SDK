using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NHL.Client.Exceptions;
using NHL.Client.RequestModels;
using NHL.Client.Resources;
using NHL.Data.Attributes;
using NHL.Data.Interfaces;
using NHL.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NHL.Client.RequestBuilders
{
    public class GeneralRequestBuilder<TModel, TRequest> : FluentBuilderBase<TModel, TRequest>
        where TModel : INHLModel
    {
        protected Type modelType = typeof(TModel);
        protected static Dictionary<Type, string> switchRequestUrl;

        static GeneralRequestBuilder()
        {
            switchRequestUrl = new Dictionary<Type, string> {
             { typeof(Conference), ApiUrls.Conferences },
             { typeof(Division), ApiUrls.Divisions },
             { typeof(Franchise), ApiUrls.Franchises },
             { typeof(Team), ApiUrls.Teams },
             { typeof(Player), ApiUrls.People }};
        }

        internal GeneralRequestBuilder(IRequestModel requestModel)
            : base(requestModel)
        {
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

            //TODO: Use Required attribute and check with default() value. Get rid from hardcoded type
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
                var parsedJObject = JObject.Parse(httpResponseContent);
                var modelJObjectAnnotationAttribute = modelType.GetCustomAttribute<ObjectAnnotationAttribute>();

                if (modelJObjectAnnotationAttribute == null)
                {
                    throw new NotSupportedException($"{this.GetType().Name} doesn't support {modelType.Name} model");
                }

                string modelJObjectAnnotation = modelJObjectAnnotationAttribute.JsonObjectName;

                return JsonConvert.DeserializeObject<List<TModel>>(parsedJObject[modelJObjectAnnotation].ToString());
            }
            catch
            {
                throw new NHLClientInternalException("Internal error on data parsing");
            }
        }
    }
}
