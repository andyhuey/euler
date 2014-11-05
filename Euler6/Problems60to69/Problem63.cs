/*
 * https://projecteuler.net/problem=63
 * Powerful digit counts
 * The answer is 49.
 * (Note that, even though I don't have the precision, the # of digits should be right.)
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems60to69
{
    class Problem63
    {
        public long soln1()
        {
            long rv = 0;
            var sw = Stopwatch.StartNew();

            // probably good enough.
            for (int x = 1; x < 1000; x++)
            {
                for (int y = 1; y < 100; y++)
                {
                    double z = Math.Pow(x, y);
                    if (z.ToString("F0").Length == y)
                    {
                        rv++;
                        Console.WriteLine("{0}^{1} -> {2:F0}", x, y, z);
                    }
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return rv;
        }
    }
}
