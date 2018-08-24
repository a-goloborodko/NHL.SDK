using NHL.Client.API;
using NHL.Client.RequestModels;
using NHL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace NHL.Client.RequestBuilders
{
    public abstract class FluentBuilderBase<TModel, TRequest>
        where TModel : INHLModel
    {
        protected IRequestModel RequestModel { get; private set; }
        protected IApiClient ApiClient { get; private set; }

        internal FluentBuilderBase(IRequestModel requestModel)
        {
            RequestModel = requestModel;
            ApiClient = new ApiClient();    //TODO: add injection
        }

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

        public async virtual Task<List<TModel>> ExecuteAsync()
        {
            ApiResult<string> responseContent = await MakeHttpRequestAsync(GenerateRequestUrl());
            return ParseHttpResult(responseContent.Result);
        }

        protected abstract string GenerateRequestUrl();
        protected abstract List<TModel> ParseHttpResult(string httpResponseContent);

        protected Task<ApiResult<string>> MakeHttpRequestAsync(string endpointUrl)
        {
            //TODO: return object with state
            return ApiClient.GetAsync<string>(new Uri(endpointUrl));
        }
    }
}
