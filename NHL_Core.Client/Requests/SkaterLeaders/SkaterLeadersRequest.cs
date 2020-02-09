using NHL.Data.Enums;
using NHL.Data.Helpers;
using NHL.Data.Interfaces;
using NHL_Core.Client.Constants;
using System.Collections.Specialized;

namespace NHL_Core.Client.Requests
{
    public class SkaterLeadersRequest<TResult> : Request<TResult>
         where TResult : class, ISkaterLeaderModel, new()
    {
        protected SeasonEnum SeasonId { get; private set; }
        protected GameTypeEnum GameType { get; private set; }

        #region ctors

        internal SkaterLeadersRequest()
        {
            SeasonId = SeasonHelper.GetCurrectSeason();
            GameType = GameTypeEnum.RegularSeason;
        }

        #endregion

        #region Public Methods

        public SkaterLeadersRequest<TResult> SetSeasonId(SeasonEnum seasonId)
        {
            SeasonId = seasonId;
            return this;
        }

        public SkaterLeadersRequest<TResult> SetGameType(GameTypeEnum gameType)
        {
            GameType = gameType;
            return this;
        }

        #endregion

        #region Overrides

        protected override NameValueCollection GetQueryStringParameters()
        {
            var baseQueryParameters = base.GetQueryStringParameters();

            var cayenneExpressionParamValue = $"{QueryParameterConstants.Season}={((int)SeasonId).ToString()} and {QueryParameterConstants.GameType}={((int)GameType).ToString()}";

            baseQueryParameters.Add(QueryParameterConstants.CayenneExpression, cayenneExpressionParamValue);

            return baseQueryParameters;
        }

        #endregion
    }
}
