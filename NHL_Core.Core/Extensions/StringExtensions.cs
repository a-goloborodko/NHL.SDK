using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NHL_Core.Tests")]
[assembly: InternalsVisibleTo("NHL_Core.Data")]
[assembly: InternalsVisibleTo("NHL_Core.Client")]
namespace NHL.Core.Extensions
{
    internal static class StringExtensions
    {
        public static bool HasValue(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}