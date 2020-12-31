using NHL.Data.Interfaces;
using NHL_Core.Client.RequestHandlers;

namespace NHL_Core.Client.Requests
{
    public class STARequest<TResult> : STARequestBase<TResult>
        where TResult : class, INHLModel, new()
    {
        internal STARequest()
            : base(new STARequestHandlerBase<TResult>())
        {
        }
    }
}