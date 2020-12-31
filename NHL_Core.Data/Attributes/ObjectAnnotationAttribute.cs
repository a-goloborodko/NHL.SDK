using System;
using NHL.Core.Extensions;

namespace NHL.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ObjectAnnotationAttribute : Attribute
    {
        public string JsonObjectName { get; }

        public ObjectAnnotationAttribute(string jsonObjectName) => JsonObjectName = jsonObjectName.HasValue() ?
            jsonObjectName :
            throw new ArgumentNullException(nameof(jsonObjectName));
    }
}