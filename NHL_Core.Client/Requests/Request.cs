using NHL.Data.Interfaces;
using NHL_Core.Client.RequestHandlers;

namespace NHL_Core.Client.Requests
{
    public class Request<TResult> : RequestBase<TResult>
        where TResult : class, INHLModel, new()
    {
        #region ctors

        internal Request()
            : base(new RequestHandlerBase<TResult>())
        {
        }

        #endregion
    }
}