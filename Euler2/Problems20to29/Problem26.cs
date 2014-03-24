/*
 * http://projecteuler.net/problem=26
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace Problems20to29
{
    class Problem26
    {
        public long soln1()
        {
            long n = 0;
            var sw = Stopwatch.StartNew();

            for (int i = 1; i <= 10; i++)
            {
                messingAround(i);
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return n;
        }

        private void messingAround(int denom)
        {
            // figure out 1/denom...
            int n, r = 1, start;
            List<int> result = new List<int>();

            Console.WriteLine("Processing 1/{0}...", denom);
            while (r != 0) 
            {
                n = (r * 10) / denom;
                r = (r * 10) % denom;

                if (result.Contains(n))
                {
                    start = result.IndexOf(n);
                    Console.WriteLine("Result starts repeating at pos {0}, for a length of {1}.", start, result.Count - start);
                    break;
                }
                result.Add(n);
            }
            Console.WriteLine("1/{0} --> 0.{1}", denom, string.Join(" ", result));
        }
    }
}
