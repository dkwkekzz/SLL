using System;
using System.Collections.Generic;
using System.Threading;
using SLL.Extensions;
using SLL.Collections;

namespace Test
{
    class TestPool
    {
        class Context : SLL.Manages.PoolingObject<Context>
        {
            public int id;
            public string name;
            public string description;
        }

        public static void Run()
        {
            var ctxlist = new List<Context>();
            for (int i = 0; i != 10000; i++)
            {
                var a = Context.Create();
                ctxlist.Add(a);
            }

            for (int i = 0; i != ctxlist.Count; i++)
            {
                Context.Destroy(ctxlist[i]);
            }
        }
    }

    class TestArray
    {
        public static void Run()
        {
            var a = new int[9999];
            a[5] = 10;
            if (a.TryGetSafety(1023, out int val1))
                Console.WriteLine("found1");
            if (a.TryGetSafety(100033, out int val2))
                Console.WriteLine("found2");
        }
    }

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

    class TestStringExt
	{
		enum EPower
		{
			A,
			B,
			C,
			D
		}

		public static void Run()
		{
			SLL.Develops.Tracer.Assert(DateTime.Parse("2013-12-05") == "2013-12-05".ToDate());
			Console.WriteLine("울트라파워".Reverse());
			Console.WriteLine("And the test methods".GetLast(6));
			Console.WriteLine(" 9893330".IsNumeric());
			Console.WriteLine("3330".IsNumeric());
			Console.WriteLine("3330".ExtractNumber());
			Console.WriteLine(" 9893330".ExtractNumber());
			Console.WriteLine(" adfaf9893330asdfasf".ExtractNumber());
			Console.WriteLine(" adfaf9893330asd33fasf".ExtractNumber());

			EPower.A.Has(EPower.B);
		}
	}

    class TestStaticInit
    {
        /// <summary>
        /// 정적 생성자를 선언하면 프로그램이 시작할때 호출되므로 해당 객체를 만들 수 밖에 없다.
        /// 하지만 선언하지 않으면 BeforeFieldInit속성을 추가하여 최대한 지연하여 객체를 생성한다. 
        /// 즉, 정적 객체 혹은 함수에 접근하기 전까지는 생성하지 않는다.
        /// </summary>
        public static void Run()
        {
            var a1 = new int[5];
            var iter = a1.GetArrayEnumerator();

            var ticker = new SLL.Manages.Ticker();
            //Console.WriteLine($"0:{SLL.Manages.Ticker.Elapsed.ToString()}");

            var centuryBegin = new DateTime(2001, 1, 1);
            var currentDate = DateTime.Now;
            var _startTicks = currentDate.Ticks - centuryBegin.Ticks;
            Console.WriteLine($"1:{_startTicks.ToString()}");

            Thread.Sleep(1000);

            Console.WriteLine($"2:{SLL.Manages.Ticker.StartTicks.ToString()}");
        }
    }
}
