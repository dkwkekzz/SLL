using System;
using System.Collections;
using System.Collections.Generic;

namespace SLL.Collections
{
    public struct ReverseEnumerator<T> : IEnumerator<T>
    {
        private List<T> list;
        private int index;

        public T Current => list[index];
        T IEnumerator<T>.Current => this.Current;
        object IEnumerator.Current => this.Current;

        public ReverseEnumerator(List<T> list)
        {
            this.list = list;
            this.index = list.Count;
        }

        public bool MoveNext()
        {
            this.index--;
            if (this.index <= 0) { return false; }
            return true;
        }

        public void Reset()
        {
            this.index = list.Count;
        }

        public void Dispose()
        {
        }
    }

}
