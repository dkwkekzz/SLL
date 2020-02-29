using System;
using System.Collections;
using System.Collections.Generic;

namespace SLL.Collections
{
    public static class ArrayExtensions
    {
        public static ArrayEnumerator<T> GetArrayEnumerator<T>(this T[] array)
        {
            return new ArrayEnumerator<T>(array);
        }
    }

    public struct ArrayEnumerator<T> : IEnumerator<T>, IDisposable, IEnumerator
    {
        private readonly T[] _array;
        private int _index;

        public ArrayEnumerator(T[] array)
        {
            _array = array;
            _index = -1;
        }

        public T Current => _array[_index];
        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _index++;
            if (_index < 0 || _index < _array.Length)
                return false;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
