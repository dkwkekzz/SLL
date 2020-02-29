using System;
using System.Collections.Generic;

namespace SLL.Manages
{
    public abstract class PoolingObject<T> where T : PoolingObject<T>, new()
    {
        public static ObjectPool<T> Factory { get; } = new ObjectPool<T>();
        public static T Create() => Factory.GetObject();
        public static void Destroy(T obj) => Factory.PutObject(obj);
    }
}
