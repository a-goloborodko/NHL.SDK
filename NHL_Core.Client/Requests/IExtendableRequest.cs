using NHL.Data.Interfaces;
using System;
using System.Linq.Expressions;

namespace NHL_Core.Client.Requests
{
    public interface IExtendableRequest<TResult, TExtend> : IRequest<TResult>
        where TResult : INHLModel
    {
        IExtendableRequest<TResult, TExtend> Include<TProperty>(Expression<Func<TExtend, TProperty>> include);
    }
}