using NHL.Data.Interfaces;
using NHL_Core.Client.Attributes;
using NHL_Core.Client.Constants;
using NHL_Core.Client.RequestHandlers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;

namespace NHL_Core.Client.Requests
{
    public class ExtendableRequestBase<TResult, TExtend> : RequestBase<TResult>, IExtendableRequest<TResult, TExtend>
        where TResult : class, INHLModel, new()
    {
        protected List<string> IncludeProperties = new List<string>();

        #region ctors

        public ExtendableRequestBase()
            : base(new RequestHandlerBase<TResult>())
        {
        }

        #endregion

        #region Public Methods

        public virtual IExtendableRequest<TResult, TExtend> Include<TProperty>(Expression<Func<TExtend, TProperty>> include)
        {
            var property = GetPropertyInfo(include);

            var includePropertyName = property.GetCustomAttributes(true)
               .OfType<RequestQueryParameterNameAttribute>()
               .FirstOrDefault()
               .QueryParameterName;

            if (IncludeProperties.Any(x => x.Equals(includePropertyName)))
            {
                throw new ArgumentException($"Property {property.Name} already included");
            }

            IncludeProperties.Add(includePropertyName);

            return this;
        }

        #endregion

        #region Overrides

        protected override NameValueCollection GetQueryStringParameters()
        {
            if (!IncludeProperties.Any())
            {
                return base.GetQueryStringParameters();
            }

            var baseQueryParameters = base.GetQueryStringParameters();

            foreach (var includeProp in IncludeProperties)
            {
                baseQueryParameters.Add(QueryParameterConstants.Include, includeProp);
            }

            return baseQueryParameters;
        }

        #endregion
    }
}