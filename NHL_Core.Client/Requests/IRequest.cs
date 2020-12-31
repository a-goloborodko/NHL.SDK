using NHL.Data.Interfaces;
using NHL_Core.Client.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NHL_Core.Client.Requests
{
    public interface IRequest<TResult>
        where TResult : INHLModel
    {
        ValidationState Validate();
        Task<RequestResponse<TResult>> ExecuteAsync();
        IRequest<TResult> OrderBy<TProperty>(Expression<Func<TResult, TProperty>> keySelector);
        IRequest<TResult> OrderByDescending<TProperty>(Expression<Func<TResult, TProperty>> keySelector);
    }
}