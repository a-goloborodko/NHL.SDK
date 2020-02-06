using NHL.Core.Extensions;
using System;

namespace NHL_Core.Client.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    sealed class RequestQueryParameterNameAttribute : Attribute
    {
        public string QueryParameterName { get; }

        public RequestQueryParameterNameAttribute(string queryParameterName)
        {
            QueryParameterName = queryParameterName.HasValue() ?
                queryParameterName
                : throw new ArgumentNullException(nameof(queryParameterName));
        }
    }
}
