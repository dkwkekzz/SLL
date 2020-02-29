using System;
using System.Collections.Generic;
using System.Threading;

namespace SLL.Manages
{
    public class SingletonEx<T>
        where T : class, new()
    {
        private static T _value = null;
        public static T Instance
        {
            get
            {
                if (_value != null) return _value;

                T temp = new T();
                Interlocked.CompareExchange(ref _value, temp, null);

                return _value;
            }
        }

        protected SingletonEx()
        {
        }
    }
}
