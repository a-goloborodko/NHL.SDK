using System;
using System.Threading.Tasks;

namespace NHL.Client.API
{
    public interface IApiClient
    {
        Task<ApiResult<T>> GetAsync<T>(Uri uri);
    }
}