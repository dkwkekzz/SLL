using System;
using System.Collections.Generic;

namespace SLL.Extensions
{
	public static class TypeExtensions
    {
        public static bool HasAttribute(this Type input, Type attrType) => input.GetCustomAttributes(attrType, true).Length > 0;

        public static bool HasAttribute(this Type input, Type attrType, Predicate<Attribute> condition)
        {
            foreach (Attribute attr in input.GetCustomAttributes(attrType, true))
            {
                if (condition(attr)) { return true; }
            }
            return false;
        }

        public static bool HasInterface(this Type input, string iName) => input.GetInterface(iName) != null;

    }
}
