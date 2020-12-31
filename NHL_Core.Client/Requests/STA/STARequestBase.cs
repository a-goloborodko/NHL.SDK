using NHL.Core.Extensions;
using NHL.Data.Interfaces;
using NHL_Core.Client.Constants;
using NHL_Core.Client.Models;
using NHL_Core.Client.RequestHandlers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace NHL_Core.Client.Requests
{
    public class STARequestBase<TResult> : ISTARequest<TResult>
        where TResult : class, INHLModel, new()
    {
        protected IRequestHandler<TResult> _requestHandler;
        protected NameValueCollection QueryParameters { get; set; }

        internal STARequestBase(IRequestHandler<TResult> requestHandler)
        {
            _requestHandler = requestHandler ?? throw new ArgumentNullException(nameof(requestHandler));
            QueryParameters = new NameValueCollection();
        }

        #region Public Methods

        public virtual Task<RequestResponse<TResult>> ExecuteAsync()
        {
            return _requestHandler.ExecuteRequestAsync(GetRequestUri());
        }

        public List<string> Validate()
        {
            return new List<string>();
        }

        #endregion

        #region Protected Methods

        protected void AddQueryParameter(string key, string value)
        {
            if (!key.HasValue())
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (!value.HasValue())
            {
                throw new ArgumentNullException(nameof(value));
            }

            var existedValue = QueryParameters[key];

            if (!existedValue.HasValue())
            {
                QueryParameters.Add(key, value);
                return;
            }

            QueryParameters[key] = $"{existedValue},{value}";
        }

        protected virtual string GetQueryString()
        {
            if (QueryParameters.Keys.Count == 0)
            {
                return null;
            }

            return QueryParameters.ToQueryString();
        }

        protected virtual Uri GetRequestUri()
        {
            var requestUrl = APIConstants.RequestUrls[typeof(TResult)];

            if (requestUrl == null)
            {
                throw new NotSupportedException($"Url for model {typeof(TResult)} not supported");
            }

            var requestModelQueryParams = GetQueryString();

            if (!requestModelQueryParams.HasValue())
            {
                return requestUrl;
            }

            return new Uri(requestUrl, requestModelQueryParams);
        }

        protected PropertyInfo GetPropertyInfo<TSource, TProperty>(
    Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);

            MemberExpression member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda.ToString()));

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda.ToString()));


            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a property that is not from type {1}.",
                    propertyLambda.ToString(),
                    type));

            return propInfo;
        }

        #endregion
    }
}