using NHL.Core.Extensions;
using NHL.Data.Interfaces;
using NHL_Core.Client.Constants;
using NHL_Core.Client.Models;
using NHL_Core.Client.RequestHandlers;
using NHL_Core.Client.RequestModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHL_Core.Client.Requests
{
    public class RequestBase<TResult, TRequestModel> : IRequest<TResult, TRequestModel>
        where TResult : class, INHLModel, new()
        where TRequestModel : class, IRequestModel<TResult>, new()
    {
        public TRequestModel Set { get; private set; }
        protected IRequestHandler<TResult> _requestHandler;

        internal RequestBase(IRequestHandler<TResult> requestHandler, TRequestModel requestModel)
        {
            _requestHandler = requestHandler ?? throw new ArgumentNullException(nameof(requestHandler));
            Set = requestModel ?? throw new ArgumentNullException(nameof(requestModel));
        }

        public virtual Task<RequestResponse<TResult>> ExecuteAsync()
        {
            return _requestHandler.ExecuteRequestAsync(GetRequestUri());
        }

        public List<string> Validate()
        {
            return Set.Validate();
        }

        protected virtual Uri GetRequestUri()
        {
            var requestUrl = APIConstants.RequestUrls[typeof(TResult)];

            if (requestUrl == null)
            {
                throw new NotSupportedException($"Url for model {typeof(TResult)} not supported");
            }

            var requestModelQueryParams = Set.GetRequestQueryParameters();

            if (!requestModelQueryParams.HasValue())
            {
                return requestUrl;
            }

            return new Uri(requestUrl, requestModelQueryParams);
        }
    }
}