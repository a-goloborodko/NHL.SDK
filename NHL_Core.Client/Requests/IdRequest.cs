using NHL.Data.Interfaces;
using NHL_Core.Client.RequestHandlers;

namespace NHL_Core.Client.Requests
{
    public class IdRequest<TResult> : RequestBase<TResult>
        where TResult : class, INHLModel, new()
    {
        protected int _Id { get; set; }

        internal IdRequest()
            : base(new RequestHandlerBase<TResult>())
        {
        }

        public IdRequest<TResult> SetId(int id)
        {
            _Id = id;

            return this;
        }

        #region Overrides

        protected override string GetQueryString()
        {
            var queryString = base.GetQueryString();

            if (_Id == 0)
            {
                return queryString;
            }

            return $"{_Id.ToString()}{queryString}";
        }

        #endregion
    }
}