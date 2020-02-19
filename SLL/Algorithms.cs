using System;
using System.Collections.Generic;

namespace SLL
{
    public static class Algorithms
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

    }
}
