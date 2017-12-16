using NHL.Client.RequestModels;
using NHL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace NHL.Client.RequestBuilders
{
    public abstract class FluentBuilderBase<TModel, TRequest>
        where TModel : INHLModel
    {
        internal FluentBuilderBase(IRequestModel requestModel)
        {
            RequestModel = requestModel;
        }

        protected IRequestModel RequestModel { get; private set; }

        protected FluentBuilderBase<TModel, TRequest> SetProperty<TPropertyType>(Expression<Func<TRequest, TPropertyType>> property, TPropertyType value)
        {
            PropertyInfo propertyInfo = null;

            if (property.Body is MemberExpression)
            {
                propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;
            }
            else
            {
                propertyInfo = (((UnaryExpression)property.Body).Operand as MemberExpression).Member as PropertyInfo;
            }

            propertyInfo.SetValue(RequestModel, value, null);

            return this;
        }

        public async virtual Task<List<TModel>>ExecuteAsync()
        {
            string responseContent = await MakeHttpRequestAsync(GenerateRequestUrl());
            return ParseHttpResult(responseContent);
        }

        protected abstract string GenerateRequestUrl();
        protected abstract List<TModel> ParseHttpResult(string httpResponseContent);

        protected async Task<string> MakeHttpRequestAsync(string endpointUrl)
        {
            //TODO: return object with state
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(endpointUrl))
            {
                if (!response.IsSuccessStatusCode)
                    return string.Empty;

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
