using Newtonsoft.Json;
using NHL.Core.Extensions;
using NHL.Data.Interfaces;
using NHL_Core.Client.Constants;
using NHL_Core.Client.Models;
using NHL_Core.Client.RequestHandlers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace NHL_Core.Client.Requests
{
    public class RequestBase<TResult> : IRequest<TResult>
        where TResult : class, INHLModel, new()
    {
        protected IRequestHandler<TResult> _requestHandler;
        protected List<SortBy> SortByList = new List<SortBy>();

        #region ctors

        internal RequestBase(IRequestHandler<TResult> requestHandler)
        {
            _requestHandler = requestHandler ?? throw new ArgumentNullException(nameof(requestHandler));
        }

        #endregion

        #region Public Methods

        public virtual Task<RequestResponse<TResult>> ExecuteAsync()
        {
            var validaionState = Validate();

            if (!validaionState.IsValid)
            {
                return Task.FromResult(RequestResponse<TResult>.Fail(validaionState.Errors));
            }

            return _requestHandler.ExecuteRequestAsync(GetRequestUri());
        }

        public virtual IRequest<TResult> OrderBy<TProperty>(Expression<Func<TResult, TProperty>> keySelector)
        {
            var property = GetPropertyInfo(keySelector);
            var propertyKey = property.Name.FirstLetterToLower();

            if (SortAlreadyExists(propertyKey))
            {
                throw new ArgumentException($"Sorting by {property.Name} already added");
            }

            SortByList.Add(new SortBy(propertyKey, QueryParameterConstants.SortDericationConstants.ASC));

            return this;
        }

        public virtual IRequest<TResult> OrderByDescending<TProperty>(Expression<Func<TResult, TProperty>> keySelector)
        {
            var property = GetPropertyInfo(keySelector);
            var propertyKey = property.Name.FirstLetterToLower();

            if (SortAlreadyExists(propertyKey))
            {
                throw new ArgumentException($"Sorting by {property.Name} already added");
            }

            SortByList.Add(new SortBy(propertyKey, QueryParameterConstants.SortDericationConstants.DESC));

            return this;
        }

        public virtual ValidationState Validate()
        {
            return ValidationState.Valid;
        }

        #endregion

        #region Protected Methods

        protected virtual NameValueCollection GetQueryStringParameters()
        {
            var queryStringParameters = new NameValueCollection();

            if (SortByList.Any())
            {
                queryStringParameters.Add(QueryParameterConstants.Sort, JsonConvert.SerializeObject(SortByList));
            }

            return queryStringParameters;
        }

        protected virtual Uri GetRequestUri()
        {
            var requestUri = APIConstants.RequestUrls[typeof(TResult)];

            if (requestUri == null)
            {
                throw new NotSupportedException($"Url for model {typeof(TResult)} not supported");
            }

            var queryStringParameters = GetQueryStringParameters();

            if (queryStringParameters.Keys.Count == 0)
            {
                return requestUri;
            }

            return new Uri(requestUri, queryStringParameters.ToQueryString());
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

        #region Private Methods

        private bool SortAlreadyExists(string propertyName)
        {
            var existedSorting = SortByList.FirstOrDefault(x => x.Property.Equals(propertyName));

            return existedSorting != null;
        }

        #endregion
    }
}
