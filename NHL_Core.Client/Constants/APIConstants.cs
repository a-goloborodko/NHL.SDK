using NHL.Data.Models;
using System;
using System.Collections.Generic;

namespace NHL_Core.Client.Constants
{
    internal static class APIConstants
    {
        public static readonly Dictionary<Type, Uri> RequestUrls = new Dictionary<Type, Uri>() {
            { typeof(STAConference), new Uri(APIUrls.STAConferences) },
            { typeof(STADivision), new Uri(APIUrls.STADivisions) },
            { typeof(STAFranchise), new Uri(APIUrls.STAFranchises) },
            { typeof(STAeam), new Uri(APIUrls.STATeams) },
            { typeof(STAPlayer), new Uri(APIUrls.STAPeople) },
            { typeof(Season), new Uri(APIUrls.Seasons) },
            { typeof(CurrentSeason), new Uri(APIUrls.CurrentSeason) },
            { typeof(Country), new Uri(APIUrls.Countries) },
            { typeof(Franchise), new Uri(APIUrls.Franchises) },
            { typeof(Draft), new Uri(APIUrls.Drafts) },
            { typeof(SkaterLeaderByPoints), new Uri(APIUrls.SkaterLeaderByPoints) },
        };

        internal static class APIUrls
        {
            public const string STAConferences = "https://statsapi.web.nhl.com/api/v1/conferences/";
            public const string STADivisions = "https://statsapi.web.nhl.com/api/v1/divisions/";
            public const string STAFranchises = "https://statsapi.web.nhl.com/api/v1/franchises/";
            public const string STAPeople = "https://statsapi.web.nhl.com/api/v1/people/";
            public const string STATeams = "https://statsapi.web.nhl.com/api/v1/teams/";
            public const string Seasons = "https://api.nhle.com/stats/rest/en/season/";
            public const string CurrentSeason = "https://api.nhle.com/stats/rest/en/componentSeason";
            public const string Countries = "https://api.nhle.com/stats/rest/en/country";
            public const string Franchises = "https://api.nhle.com/stats/rest/en/franchise";
            public const string Drafts = "https://api.nhle.com/stats/rest/en/draft";
            public const string SkaterLeaderByPoints = "https://api.nhle.com/stats/rest/en/leaders/skaters/points";
        }
    }
}