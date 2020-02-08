using NHL.Data.Models;
using NHL_Core.Client.Attributes;
using NHL_Core.Client.Constants;
using NHL_Core.Client.RequestModels;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NHL_Core.Client.Requests
{
    public class STAPlayersRequest : STAIdRequest<STAPlayer>
    {
        internal STAPlayersRequest()
            : base()
        {
        }

        public STAPlayersRequest Include<TProperty>(Expression<Func<STAPlayerStatisticRequestModel, TProperty>> include)
        {
            var property = GetPropertyInfo(include);

            var requestParamName = property.GetCustomAttributes(true)
                .OfType<RequestQueryParameterNameAttribute>()
                .FirstOrDefault()
                .QueryParameterName;

            if (QueryParameters.Keys.Count == 0)
            {
                AddQueryParameter(STAQueryParameterConstants.Expand, "person.stats,stats.team");
            }

            AddQueryParameter(STAQueryParameterConstants.Stats, requestParamName);

            return this;
        }
    }
}