using Newtonsoft.Json;
using NHL.Core.Extensions;
using System;

namespace NHL_Core.Client.Models
{
    public class SortBy
    {
        [JsonProperty("property")]
        public string Property { get; }

        [JsonProperty("direction")]
        public string Direction { get; }

        public SortBy(string property, string direction)
        {
            Property = property.HasValue() ? property : throw new ArgumentNullException(nameof(property));
            Direction = direction;
        }
    }
}