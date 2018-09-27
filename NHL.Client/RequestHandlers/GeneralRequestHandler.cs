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
using System.Reflection;

namespace NHL.Client.RequestHandlers
{
    public sealed class GeneralRequestHandler<TResult> : RequestHandlerBase<List<TResult>, GeneralRequestModel>
    {
        private static readonly Dictionary<Type, string> switchRequestUrl;
        private static string jsonObjectAnnotationName;

        protected override Type ModelType => base.ModelType.GetGenericArguments()[0];

        #region ctors
        static GeneralRequestHandler()
        {
            switchRequestUrl = new Dictionary<Type, string> {
             { typeof(Conference), ApiUrls.Conferences },
             { typeof(Division), ApiUrls.Divisions },
             { typeof(Franchise), ApiUrls.Franchises },
             { typeof(Team), ApiUrls.Teams },
             { typeof(Player), ApiUrls.People }};
        }

        internal GeneralRequestHandler()
        {
            jsonObjectAnnotationName = ModelType.GetCustomAttribute<ObjectAnnotationAttribute>()?.JsonObjectName;
        }
        #endregion

        protected override Uri GenerateUrl(GeneralRequestModel request)
        {
            string requestUrl = switchRequestUrl[ModelType];

            if (string.IsNullOrWhiteSpace(requestUrl))
            {
                throw new Exception(string.Format("model type {0} not supported.", ModelType));
            }

            //TODO: Use Required attribute and check with default() value. Get rid from hardcoded type
            if (ModelType == typeof(Player) && request.Id == 0)
            {
                throw new ArgumentException("request must include a valid person Id");
            }

            if (request.Id != 0)
            {
                requestUrl += request.Id;
            }

            return new Uri(requestUrl);
        }

        protected override List<TResult> ParseResponse(string response)
        {
            if (string.IsNullOrWhiteSpace(response))
            {
                return new List<TResult>();
            }

            try
            {
                var parsedJObject = JObject.Parse(response);

                if (string.IsNullOrWhiteSpace(jsonObjectAnnotationName))
                {
                    throw new NotSupportedException($"{this.GetType().Name} doesn't support {ModelType.Name} model");
                }

                return JsonConvert.DeserializeObject<List<TResult>>(parsedJObject[jsonObjectAnnotationName].ToString());
            }
            catch
            {
                throw new NHLClientInternalException("Internal error on data parsing");
            }
        }
    }
}