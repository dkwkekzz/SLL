using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class TestSplayBT
    {
        public static void Run()
        {
            var tree = new SLL.Collections.SplayBT<int, int>();
            tree.Add(435, 12311);
            tree.Add(34222, 12311);
            tree.Add(33, 412311);
            tree.Add(123566, 233);
            tree.Add(123, 122);
            Console.WriteLine(tree.ToString());
            tree.Remove(123);
            Console.WriteLine(tree.ToString());
            tree.Add(33, 3333);
            tree.TryAdd(33, 9999);
            Console.WriteLine(tree.ToString());
            tree.Add(33, 7777);
            Console.WriteLine(tree.ToString());
            tree.Add(33, 7778);
            Console.WriteLine(tree.ToString());
            tree.Add(33, 7777);
            Console.WriteLine(tree.ToString());
            tree.Add(124, 12332);
            tree.Add(3, 12332);

            Console.WriteLine("===iterate===");
            var iter = tree.GetEnumerator();
            while (iter.MoveNext())
            {
                Console.WriteLine(iter.Current.ToString());
            }

            Console.WriteLine("===backiterate===");
            while (iter.MovePrev())
            {
                Console.WriteLine(iter.Current.ToString());
            }
            Console.WriteLine("===randomiterate===");
            if (iter.Advance(4))
                Console.WriteLine(iter.Current.ToString());
            else
                Console.WriteLine("fail to advance...");

            tree.Add(992, 77345);
            Console.WriteLine("===BidirectEnumerator===");
            var bidIter = tree.GetEnumerator(33);
            while (bidIter.MoveNext())
            {
                Console.WriteLine(bidIter.Current.ToString());
            }
            Console.WriteLine("=============");

            if (tree.ContainsKey(123566))
            {
                Console.WriteLine("found: 123566");
            }
            Console.WriteLine(tree.ToString());

            int v;
            if (tree.TryGetValue(34222, out v))
            {
                Console.WriteLine(string.Format("found: 34222, {0}", v.ToString()));
            }
            Console.WriteLine(tree.ToString());

            Console.WriteLine("remove: 34222");
            tree.Remove(34222);
            Console.WriteLine(tree.ToString());

            //Console.WriteLine("removeone: 123566");
            //tree.RemoveOne(123566, 233);
            //Console.WriteLine(tree.ToString());
            //
            //Console.WriteLine("removeone: 33");
            //tree.RemoveOne(33, 9999);
            //Console.WriteLine(tree.ToString());
            //
            //Console.WriteLine("delete: 33");
            //int key = 33;
            //int value = 7777;
            //tree.delete(ref key, ref value);
            //Console.WriteLine(tree.ToString());

            Console.WriteLine("remove: 33");
            tree.Remove(33);
            Console.WriteLine(tree.ToString());
        }
    }
}
