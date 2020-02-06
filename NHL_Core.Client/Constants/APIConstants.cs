using NHL.Data.Models;
using System;
using System.Collections.Generic;

namespace NHL_Core.Client.Constants
{
    internal static class APIConstants
    {
        public static readonly Dictionary<Type, Uri> RequestUrls = new Dictionary<Type, Uri>() {
            { typeof(Conference), new Uri(APIUrls.Conferences) },
            { typeof(Division), new Uri(APIUrls.Divisions) },
            { typeof(Franchise), new Uri(APIUrls.Franchises) },
            { typeof(Team), new Uri(APIUrls.Teams) },
            { typeof(Player), new Uri(APIUrls.People) },
            { typeof(Season), new Uri(APIUrls.Seasons) },
            { typeof(CurrentSeason), new Uri(APIUrls.CurrentSeason) },
        };

        internal static class APIUrls
        {
            public const string Conferences = "https://statsapi.web.nhl.com/api/v1/conferences/";
            public const string Divisions = "https://statsapi.web.nhl.com/api/v1/divisions/";
            public const string Franchises = "https://statsapi.web.nhl.com/api/v1/franchises/";
            public const string People = "https://statsapi.web.nhl.com/api/v1/people/";
            public const string Teams = "https://statsapi.web.nhl.com/api/v1/teams/";
            public const string Seasons = "https://api.nhle.com/stats/rest/en/season/";
            public const string CurrentSeason = "https://api.nhle.com/stats/rest/en/componentSeason";
        }
    }
}