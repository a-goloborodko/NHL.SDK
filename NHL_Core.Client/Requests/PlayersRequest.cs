using NHL.Data.Models;
using NHL_Core.Client.Attributes;
using NHL_Core.Client.Constants;
using NHL_Core.Client.RequestModels;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NHL_Core.Client.Requests
{
    public class PlayersRequest : IdRequest<Player>
    {
        internal PlayersRequest()
            : base()
        {
        }

        public PlayersRequest Include<TProperty>(Expression<Func<PlayerStatisticRequestModel, TProperty>> include)
        {
            var property = GetPropertyInfo(include);

            var requestParamName = property.GetCustomAttributes(true)
                .OfType<RequestQueryParameterNameAttribute>()
                .FirstOrDefault()
                .QueryParameterName;

            if (QueryParameters.Keys.Count == 0)
            {
                AddQueryParameter(QueryParameterConstants.Expand, "person.stats,stats.team");
            }

            AddQueryParameter(QueryParameterConstants.Stats, requestParamName);

            return this;
        }
    }
}