using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NHL_Core.Tests")]
[assembly: InternalsVisibleTo("NHL_Core.Data")]
[assembly: InternalsVisibleTo("NHL_Core.Client")]
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