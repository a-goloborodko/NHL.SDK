using NHL.Data.Enums;
using System;

namespace NHL.Data.Helpers
{
    public static class SeasonHelper
    {
        public static SeasonEnum GetCurrectSeason()
        {
            DateTime _now = DateTime.Now.Date;

            if (_now.Month <= 8)
            {
                return (SeasonEnum)((_now.Year - 1) * 10000 + _now.Year);
            }

            return (SeasonEnum)(_now.Year * 10000 + _now.Year + 1);
        }
    }
}