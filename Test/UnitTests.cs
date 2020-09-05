using System;
using System.Collections.Generic;
using System.Threading;
using SLL.Extensions;
using SLL.Collections;

namespace Test
{
    struct Big
    {
        public long l1;
        public long l2;
        public long l3;
        public long l4;
        public long l5;
        public long l6;
        public long l7;
        public long l8;
        public long l9;
        public long l10;
        public long l11;
        public long l12;
        public long l13;
        public long l14;
        public long l15;
        public long l16;
        public long l17;
        public long l18;
        public long l19;
        public long l20;
        public long l21;
        public long l22;
        public long l23;
        public long l24;
        public long l25;
        public long l26;
        public long l27;
        public long l28;
        public long l29;
        public long l30;
        public long l31;
        public long l32;
        public long l33;
        public long l34;
        public long l35;
        public long l36;
        public long l37;
        public long l38;
        public long l39;
        public long l40;
        public long l41;
        public long l42;
        public long l43;
        public long l44;
        public long l45;
        public long l46;
        public long l47;
        public long l48;
        public long l49;
        public long l50;
        public long l51;
        public long l52;
        public long l53;
        public long l54;
        public long l55;
        public long l56;
        public long l57;
        public long l58;
        public long l59;
        public long l60;
        public long l61;
        public long l62;
        public long l63;
        public long l64;
        public long l65;
        public long l66;
        public long l67;
        public long l68;
        public long l69;
        public long l70;
        public long l71;
        public long l72;
        public long l73;
        public long l74;
        public long l75;
        public long l76;
        public long l77;
        public long l78;
        public long l79;
        public long l80;
        public long l81;
        public long l82;
        public long l83;
        public long l84;
        public long l85;
        public long l86;
        public long l87;
        public long l88;
        public long l89;
        public long l90;
        public long l91;
        public long l92;
        public long l93;
        public long l94;
        public long l95;
        public long l96;
        public long l97;
        public long l98;
        public long l99;
        public long l100;
        public long l101;
        public long l102;
        public long l103;
        public long l104;
        public long l105;
        public long l106;
        public long l107;
        public long l108;
        public long l109;
        public long l110;
        public long l111;
        public long l112;
        public long l113;
        public long l114;
        public long l115;
        public long l116;
        public long l117;
        public long l118;
        public long l119;
        public long l120;
        public long l121;
        public long l122;
        public long l123;
        public long l124;
        public long l125;
        public long l126;
        public long l127;
        public long l128;
        public long l129;
        public long l130;
        public long l131;
        public long l132;
        public long l133;
        public long l134;
        public long l135;
        public long l136;
        public long l137;
        public long l138;
        public long l139;
        public long l140;
        public long l141;
        public long l142;
        public long l143;
        public long l144;
        public long l145;
        public long l146;
        public long l147;
        public long l148;
        public long l149;
        public long l150;
        public long l151;
        public long l152;
        public long l153;
        public long l154;
        public long l155;
        public long l156;
    }

    class TestHeap
    {
        static int sum = 0;

        public static void Run()
        {
            bool? canceled = false;
            Console.CancelKeyPress += (sender, e) => { canceled = true; };

            var list = new List<int>(1);
            for (int i = 0; i != 1; i++) { list.Add(i); }

            int frame = 0;
            while (true)
            {
                if (canceled.Value)
                    break;

                sum = 0;
                frame++;
                var b = new Big { l1 = frame };
                for (int i = 0; i != 1; i++)
                {
                    //var tickFrame = frame + i;
                    list.ForEach(e => { sum += (int)b.l1; });
                }
                //Console.WriteLine(sum.ToString());

                //Thread.Sleep(1000);
            }
        }

        private static void del(int e)
        {
            sum += e;
        }
    }

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
