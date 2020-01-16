using NHL.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace NHL_Core.Client.RequestModels
{
    public abstract class RequestModelBase<TResult> : IRequestModel<TResult>
        where TResult : INHLModel
    {
        //protected IRequest<TResult> Request { get; private set; }

        //public Task<RequestResponse<TResult>> ExecuteAsync()
        //{
        //    return Request.ExecuteAsync();
        //}

        public abstract string GetRequestQueryParameters();

        public List<string> Validate()
        {
            throw new NotImplementedException();
        }
    }
}