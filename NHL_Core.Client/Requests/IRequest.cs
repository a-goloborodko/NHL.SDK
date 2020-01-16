using NHL.Data.Interfaces;
using NHL_Core.Client.Models;
using NHL_Core.Client.RequestModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHL_Core.Client.Requests
{
    public interface IRequest<TResult, TRequestModel>
        where TResult : INHLModel
        where TRequestModel : class, IRequestModel<TResult>, new()
    {
        List<string> Validate();
        Task<RequestResponse<TResult>> ExecuteAsync();
    }
}