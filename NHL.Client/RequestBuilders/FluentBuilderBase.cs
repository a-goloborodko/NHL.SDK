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
    public abstract class FluentBuilderBase<T>
        where T : INHLModel
    {
        internal FluentBuilderBase(IRequestModel requestModel)
        {
            RequestModel = requestModel;
        }

        protected IRequestModel RequestModel { get; private set; }

        protected FluentBuilderBase<T> SetProperty<TPropertyType>(Expression<Func<T, TPropertyType>> property, TPropertyType value)
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

        protected async virtual Task<List<T>>ExecuteAsync()
        {
            string responseContent = await MakeHttpRequestAsync(GenerateRequestUrl());
            return ParseHttpResult(responseContent);
        }

        protected abstract string GenerateRequestUrl();
        protected abstract List<T> ParseHttpResult(string httpResponseContent);

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
