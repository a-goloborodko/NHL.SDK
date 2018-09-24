using NHL.Client.RequestHandlers;
using NHL.Client.RequestModels;
using NHL.Client.Requests;
using NHL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHL.Client.Requests
{
    public abstract class RequestBase<TResult, TRequest> : IRequest<TResult>
        //where TResult : INHLModel
        where TRequest : class, IRequestModel, new()
    {
        protected FluentBuilder<TRequest> FluentBuilder { get; }
        protected TRequest RequestModel { get; }
        private IRequestHandler<TResult, TRequest> _requestHandler;

        internal RequestBase(IRequestHandler<TResult, TRequest> requestHandler)
        {
            RequestModel = new TRequest();
            _requestHandler = requestHandler ?? throw new ArgumentNullException(nameof(requestHandler));
            FluentBuilder = new FluentBuilder<TRequest>(RequestModel);
        }

        public virtual Task<TResult> ExecuteAsync()
        {
            return _requestHandler.ExecuteRequestAsync(RequestModel);
        }
    }
}