using System;
using NHL.Data.Interfaces;
using NHL_Core.Client.RequestHandlers;

namespace NHL_Core.Client.Requests
{
    public class Request<TResult> : RequestBase<TResult>
        where TResult : class, INHLModel, new()
    {
        internal Request()
            : base(new RequestHandlerBase<TResult>())
        {
        }

        public int Id { get; set; }

        protected override Uri GetRequestUri()
        {
            var baseUri = base.GetRequestUri();
            if (Id == 0)
            {
                return baseUri;
            }

            return new Uri(baseUri, Id.ToString());
        }
    }
}