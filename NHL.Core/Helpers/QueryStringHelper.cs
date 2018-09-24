using NHL.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NHL.Core.Helpers
{
    internal static class QueryStringHelper
    {
        public static string ToQueryString(this List<KeyValuePair<string, string>> queryParams)
        {
            if (!queryParams.SafeAny())
            {
                return string.Empty;
            }

            var array = from val in queryParams
                        select string.Format("{0}={1}", val.Key, Uri.EscapeDataString(val.Value));

            return "?" + string.Join("&", array);
        }
    }
}