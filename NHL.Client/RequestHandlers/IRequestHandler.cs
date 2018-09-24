using NHL.Client.RequestModels;
using NHL.Data.Interfaces;
using System.Threading.Tasks;

namespace NHL.Client.RequestHandlers
{
    interface IRequestHandler<TResult, TRequest>
        //where TResult : INHLModel
        where TRequest : IRequestModel
    {
        Task<TResult> ExecuteRequestAsync(TRequest request);
    }
}