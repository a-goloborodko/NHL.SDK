using NHL.Data.Interfaces;
using NHL_Core.Client.Constants;
using NHL_Core.Client.Models;
using NHL_Core.Client.RequestHandlers;
using System;
using System.Threading.Tasks;

namespace NHL_Core.Client.Requests
{
    public class RequestBase<TResult> : IRequest<TResult>
        where TResult : class, INHLModel, new()
    {
        protected IRequestHandler<TResult> _requestHandler;

        internal RequestBase(IRequestHandler<TResult> requestHandler)
        {
            _requestHandler = requestHandler ?? throw new ArgumentNullException(nameof(requestHandler));
        }

        public virtual Task<RequestResponse<TResult>> ExecuteAsync()
        {
            return _requestHandler.ExecuteRequestAsync(GetRequestUri());
        }

        protected virtual Uri GetRequestUri()
        {
            var requestUrl = APIConstants.RequestUrls[typeof(TResult)];

            if (requestUrl == null)
            {
                throw new NotSupportedException($"Url for model {typeof(TResult)} not supported");
            }

            return requestUrl;
        }
    }
}