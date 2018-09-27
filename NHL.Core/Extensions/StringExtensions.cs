using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NHL.Data")]
[assembly: InternalsVisibleTo("NHL.Client")]
[assembly: InternalsVisibleTo("NHL.Tests")]
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