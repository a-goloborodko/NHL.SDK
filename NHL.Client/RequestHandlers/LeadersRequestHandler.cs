using NHL.Client.RequestModels;
using NHL.Client.Resources;
using NHL.Core.Helpers;
using NHL.Data.Enums;
using NHL.Data.Model.Leaders;
using System;
using System.Collections.Generic;

namespace NHL.Client.RequestHandlers
{
    public sealed class LeadersRequestHandler : RequestHandlerBase<LeadersStatistic, LeadersRequestModel>
    {
        protected override Uri GenerateUrl(LeadersRequestModel request)
        {
            List<KeyValuePair<string, string>> requestParams = new List<KeyValuePair<string, string>>(3)
            {
                new KeyValuePair<string, string>("season", ((int)request.Season).ToString()),
                new KeyValuePair<string, string>("gameType", ((int)request.GameType).ToString())
            };

            if (request.Team != TeamEnum.ALL)
            {
                requestParams.Add(new KeyValuePair<string, string>("team", request.Team.ToString()));
            }

            return new Uri(ApiUrls.Leaders + requestParams.ToQueryString());
        }
    }
}