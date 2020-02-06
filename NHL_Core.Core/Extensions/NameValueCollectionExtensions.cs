using System;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NHL_Core.Tests")]
[assembly: InternalsVisibleTo("NHL_Core.Data")]
[assembly: InternalsVisibleTo("NHL_Core.Client")]
namespace NHL_Core.Core.Extensions
{
    internal static class NameValueCollectionExtensions
    {
        public static string ToQueryString(this NameValueCollection urlQuesryParams)
        {
            if (urlQuesryParams == null) throw new ArgumentNullException("urlQuesryParams");

            var array = (from key in urlQuesryParams.AllKeys
                         from value in urlQuesryParams.GetValues(key)
                         select string.Format("{0}={1}", key, value))
                .ToArray();
            return "?" + string.Join("&", array);
        }
    }
}
