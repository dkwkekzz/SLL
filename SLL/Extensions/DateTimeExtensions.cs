using System;
using System.Collections.Generic;
using System.Text;

namespace SLL.Extensions
{
	public static class DateTimeExtensions
	{
		public static bool Between(this DateTime dt, DateTime rangeBeg, DateTime rangeEnd)
		{
			return dt.Ticks >= rangeBeg.Ticks && dt.Ticks <= rangeEnd.Ticks;
		}
	}
}
