using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SLL.Manages
{
    public class Ticker
    {
        private static readonly Stopwatch _timer = Stopwatch.StartNew();

        static Ticker() { }

        public static long StartTicks { get; } = DateTime.Now.Ticks - new DateTime(2001, 1, 1).Ticks;
        public static long GlobalTicks => StartTicks + _timer.Elapsed.Ticks;
        public static long ElapsedTicks => _timer.ElapsedTicks;
        public static long ElapsedMS => _timer.ElapsedMilliseconds;
        public static TimeSpan Elapsed => _timer.Elapsed;
    }
}
