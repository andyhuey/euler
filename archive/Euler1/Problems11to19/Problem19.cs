/*
 * http://projecteuler.net/problem=19
 * counting Sundays
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problems11to19
{
    class Problem19
    {
        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            long sundays = 0;

            DateTime dt = new DateTime(1901, 1, 1);
            DateTime dtEnd = new DateTime(2000, 12, 31);

            while (dt < dtEnd)
            {
                if (dt.DayOfWeek == DayOfWeek.Sunday)
                    sundays++;
                dt = dt.AddMonths(1);

                //if (dt.Year % 10 == 0 && dt.Month == 1)
                //    Console.WriteLine("At {0}...", dt);
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);

            return sundays;
        }
    }
}
