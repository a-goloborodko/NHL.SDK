using NHL.Data.Interfaces;
using NHL_Core.Client.RequestHandlers;
using NHL_Core.Client.RequestModels;

namespace NHL_Core.Client.Requests
{
    public class IdRequest<TResult> : RequestBase<TResult, IdRequestModel<TResult>>
        where TResult : class, INHLModel, new()
    {
        internal IdRequest()
            : base(new RequestHandlerBase<TResult>(), new IdRequestModel<TResult>())
        {
        }
    }
}