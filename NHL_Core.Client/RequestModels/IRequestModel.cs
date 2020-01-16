using NHL.Data.Interfaces;
using System.Collections.Generic;

namespace NHL_Core.Client.RequestModels
{
    public interface IRequestModel<TResult>
        where TResult : INHLModel
    {
        string GetRequestQueryParameters();
        List<string> Validate();
        //Task<RequestResponse<TResult>> ExecuteAsync();
    }
}