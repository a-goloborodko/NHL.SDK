using NHL.Client.RequestModels;
using NHL.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHL.Client.RequestHandlers
{
    interface IRequestHandler<TResult, TRequest>
        where TResult : INHLModel
        where TRequest : IRequestModel
    {
        Task<List<TResult>> ExecuteRequestAsync(TRequest request);
    }
}