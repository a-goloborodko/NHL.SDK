using NHL.Data.Interfaces;
using System.Threading.Tasks;

namespace NHL.Client.Requests
{
    public interface IRequest<TResult>
        //where TResult : INHLModel
    {
        Task<TResult> ExecuteAsync();
    }
}