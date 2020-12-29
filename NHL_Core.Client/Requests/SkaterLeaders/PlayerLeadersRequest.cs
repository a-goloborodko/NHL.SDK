using NHL.Data.Enums;
using NHL.Data.Helpers;
using NHL.Data.Interfaces;
using NHL_Core.Client.Constants;
using System.Collections.Specialized;

namespace NHL_Core.Client.Requests
{
    public class PlayerLeadersRequest<TResult> : Request<TResult>
         where TResult : class, ISkaterLeaderModel, new()
    {
        protected SeasonEnum SeasonId { get; private set; }
        protected GameTypeEnum GameType { get; private set; }

        #region ctors

        internal PlayerLeadersRequest()
        {
            SeasonId = SeasonHelper.GetCurrectSeason();
            GameType = GameTypeEnum.RegularSeason;
        }

        #endregion

        #region Public Methods

        public PlayerLeadersRequest<TResult> SetSeasonId(SeasonEnum seasonId)
        {
            SeasonId = seasonId;
            return this;
        }

        public PlayerLeadersRequest<TResult> SetGameType(GameTypeEnum gameType)
        {
            GameType = gameType;
            return this;
        }

        #endregion

        #region Overrides

        //TODO: create class that will create "cayenneExp" url part like GetQueryStringParameters do in RequestBase class
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
