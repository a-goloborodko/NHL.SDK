using NHL.Data.Enums;
using NHL.Data.Helpers;
using NHL.Data.Models;
using NHL_Core.Client.Constants;
using System.Collections.Specialized;

namespace NHL_Core.Client.Requests
{
    public class SkaterLeadersByPointsRequest : Request<SkaterLeaderByPoints>
    {
        protected SeasonEnum SeasonId { get; private set; }
        protected GameTypeEnum GameType { get; private set; }

        #region ctors

        internal SkaterLeadersByPointsRequest()
        {
            SeasonId = SeasonHelper.GetCurrectSeason();
            GameType = GameTypeEnum.RegularSeason;
        }

        #endregion

        #region Public Methods

        public SkaterLeadersByPointsRequest SetSeasonId(SeasonEnum seasonId)
        {
            SeasonId = seasonId;
            return this;
        }

        public SkaterLeadersByPointsRequest SetGameType(GameTypeEnum gameType)
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
