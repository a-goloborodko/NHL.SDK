using NHL.Data.Interfaces;
using NHL_Core.Client.Models;
using System.Threading.Tasks;

namespace NHL_Core.Client.Requests
{
    public interface IRequest<TResult>
        where TResult : INHLModel
    {
        Task<RequestResponse<TResult>> ExecuteAsync();
    }
}