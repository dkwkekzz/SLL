using System;
using System.Collections.Generic;

namespace SLL.Collections
{
    public class StringRefComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return object.ReferenceEquals(x, y);
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}
