using NHL.Data.Interfaces;
using NHL_Core.Client.Models;
using System;
using System.Threading.Tasks;

namespace NHL_Core.Client.RequestHandlers
{
    public interface IRequestHandler<TResult>
        where TResult : INHLModel
    {
        Task<RequestResponse<TResult>> ExecuteRequestAsync(Uri requestUri);
    }
}