using System;
using System.Collections.Generic;
using SLL.Extensions;

namespace Test
{
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
			SLL.Tracer.Assert(DateTime.Parse("2013-12-05") == "2013-12-05".ToDate());
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
}
