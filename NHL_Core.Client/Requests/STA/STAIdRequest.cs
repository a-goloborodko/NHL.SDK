using NHL.Data.Interfaces;
using NHL_Core.Client.RequestHandlers;

namespace NHL_Core.Client.Requests
{
    public class STAIdRequest<TResult> : STARequestBase<TResult>
        where TResult : class, INHLModel, new()
    {
        protected int _Id { get; set; }

        internal STAIdRequest()
            : base(new STARequestHandlerBase<TResult>())
        {
        }

        public STAIdRequest<TResult> SetId(int id)
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