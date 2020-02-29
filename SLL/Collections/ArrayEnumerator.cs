using System;
using System.Collections;
using System.Collections.Generic;

namespace SLL.Collections
{
    public static class ArrayExtensions
    {
        public static ArrayEnumerator<T> GetArrayEnumerator<T>(this IList<T> array)
        {
            return new ArrayEnumerator<T>(array);
        }
    }

    public struct ArrayEnumerator<T> : IEnumerator<T>, IDisposable, IEnumerator
    {
        private readonly IList<T> _array;

        public ArrayEnumerator(IList<T> array)
        {
            _array = array;
            Index = -1;
        }

        public int Index { get; private set; }

        public T Current => _array[Index];
        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            Index++;
            if (Index < 0 || Index < _array.Count)
                return false;
            return true;
        }

        public void Reset()
        {
            Index = -1;
        }
    }
}
