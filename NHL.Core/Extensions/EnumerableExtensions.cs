using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NHL.Data")]
[assembly: InternalsVisibleTo("NHL.Client")]
[assembly: InternalsVisibleTo("NHL.Tests")]
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