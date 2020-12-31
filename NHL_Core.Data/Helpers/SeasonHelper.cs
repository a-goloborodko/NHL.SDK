using NHL.Data.Enums;
using System;

namespace NHL.Data.Helpers
{
    public static class SeasonHelper
    {
        private static readonly TimeZoneInfo EasternStandardTimeZone;
        private static readonly DateTime NextFreeAgencyStartDateUTC;

        static SeasonHelper()
        {
            EasternStandardTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            var _nowInET = TimeZoneInfo.ConvertTime(DateTime.UtcNow, EasternStandardTimeZone);
            var nextFreeAgencyYear = DateTime.UtcNow.Month >= 7 && DateTime.UtcNow.Day >= 1 && _nowInET.Hour >= 12 ? DateTime.UtcNow.Year + 1 : DateTime.UtcNow.Year;

            var freeAgencyStartDateUnspec = DateTime.SpecifyKind(new DateTime(nextFreeAgencyYear, 7, 1, 12, 0, 0), DateTimeKind.Unspecified);
            NextFreeAgencyStartDateUTC = TimeZoneInfo.ConvertTimeToUtc(freeAgencyStartDateUnspec, EasternStandardTimeZone);
        }

        public static SeasonEnum GetCurrectSeason()
        {
            var _utcNow = DateTime.UtcNow;

            if (_utcNow < NextFreeAgencyStartDateUTC)
            {
                return (SeasonEnum)((NextFreeAgencyStartDateUTC.Year - 1) * 10000 + NextFreeAgencyStartDateUTC.Year);
            }

            return (SeasonEnum)(NextFreeAgencyStartDateUTC.Year * 10000 + NextFreeAgencyStartDateUTC.Year + 1);
        }
    }
}