using System;
using System.Collections;
using System.Collections.Generic;

namespace SLL.Collections
{
    public static class ArrayExtensions
    {
        public static ArrayEnumerator<T> GetArrayEnumerator<T>(this T[] arr)
        {
            return new ArrayEnumerator<T>(arr);
        }

        public static bool CheckSafety<T>(this T[] arr, int idx)
        {
            return idx >= 0 && arr.Length > idx;
        }

        public static bool TryGetSafety<T>(this T[] arr, int idx, out T value)
        {
            if (!arr.CheckSafety(idx))
            {
                value = default;
                return false;
            }

            value = arr[idx];
            return true;
        }
    }

    public struct ArrayEnumerator<T> : IEnumerator<T>, IDisposable, IEnumerator
    {
        private readonly T[] _array;

        public ArrayEnumerator(T[] array)
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
            if (Index < 0 || Index < _array.Length)
                return false;
            return true;
        }

        public bool Advance(int ofs)
        {
            Index += ofs;
            if (!_array.CheckSafety(Index))
                return false;
            return true;
        }

        public void Reset()
        {
            Index = -1;
        }
    }
}
