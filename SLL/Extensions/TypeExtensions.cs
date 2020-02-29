using System;
using System.Collections.Generic;

namespace SLL.Extensions
{
	public static class TypeExtensions
    {
        public static bool HasAttribute(this Type input, Type attrType) => input.GetCustomAttributes(attrType, true).Length > 0;
        public static bool HasAttribute<T>(this Type input) => input.GetCustomAttributes(typeof(T), true).Length > 0;

        public static bool HasAttribute(this Type input, Type attrType, Predicate<Attribute> condition)
        {
            var attrs = input.GetCustomAttributes(attrType, true);
            for (int i = 0; i != attrs.Length; i++)
            {
                if (condition(attrs[i] as Attribute)) { return true; }
            }
            return false;
        }

        public static bool HasInterface(this Type input, string iName) => input.GetInterface(iName) != null;
        public static bool HasInterface<T>(this Type input) => input.GetInterface(typeof(T).Name) != null;

    }
}
