using NHL.Client.RequestHandlers;
using NHL.Client.RequestModels;
using NHL.Data.Interfaces;
using System.Collections.Generic;

namespace NHL.Client.Requests
{
    public sealed class GeneralRequest<TResult> : RequestBase<List<TResult>, GeneralRequestModel>
    //where TResult : IIdentityNHLModel
    {
        internal GeneralRequest()
            : base(new GeneralRequestHandler<TResult>())
        {

        }

        public void SetId(int id)
        {
            FluentBuilder.SetProperty((prop) => RequestModel.Id, id);
        }
    }
}