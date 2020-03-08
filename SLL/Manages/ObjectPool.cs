using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace SLL.Manages
{
    public class ObjectPool<TValue> where TValue : class, new()
    {
        private readonly ConcurrentBag<TValue> _objects = new ConcurrentBag<TValue>();

        public Func<TValue> Generator { get; set; }
        public Action<TValue> Disposer { get; set; }
        public int Capacity => _objects.Count;

        public ObjectPool(int capacity = 0, Func<TValue> objectGenerator = null, Action<TValue> objectDisposer = null)
        {
            this.Generator = objectGenerator;
            this.Disposer = objectDisposer;

            for (int i = 0; i != capacity; i++)
            {
                var item = objectGenerator?.Invoke() ?? new TValue();
                _objects.Add(item);
            }
        }
        
        public TValue GetObject()
        {
            TValue item;
            if (_objects.TryTake(out item))
                return item;
            
            return Generator?.Invoke() ?? new TValue();
        }

        public void PutObject(TValue item)
        {
            Disposer?.Invoke(item);
            _objects.Add(item);
        }
    }
}
