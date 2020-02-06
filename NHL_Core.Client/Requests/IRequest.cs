using NHL.Data.Interfaces;
using NHL_Core.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHL_Core.Client.Requests
{
    public interface IRequest<TResult>
        where TResult : INHLModel
    {
        List<string> Validate();
        Task<RequestResponse<TResult>> ExecuteAsync();
    }
}