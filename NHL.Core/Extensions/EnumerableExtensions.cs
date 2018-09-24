using System.Collections.Generic;
using System.Linq;

namespace NHL.Core.Extensions
{
    internal static class EnumerableExtensions
    {
        internal static bool SafeAny<T>(this IEnumerable<T> source)
        {
            if (source == null) return false;

            return source.Any();
        }
    }
}