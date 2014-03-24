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
        public int soln1()
        {
            int longestRepeatDenom = 0, longestRepeatLen = 0;
            int len;

            var sw = Stopwatch.StartNew();

            for (int d = 1; d < 1000; d++)
            {
                len = checkFraction(d);
                if (len > longestRepeatLen)
                {
                    longestRepeatLen = len;
                    longestRepeatDenom = d;
                }
            }

            sw.Stop();
            Console.WriteLine("Longest repeating length is {0} for denominator {1}",
                longestRepeatLen, longestRepeatDenom);
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return longestRepeatDenom;
        }

        private int checkFraction(int denom)
        {
            // figure out 1/denom...
            int n, r = 1, start;
            List<int> result = new List<int>();
            List<int> remainders = new List<int>();

            Console.WriteLine("Processing 1/{0}...", denom);
            while (r != 0) 
            {
                n = (r * 10) / denom;
                r = (r * 10) % denom;

                if (remainders.Contains(r))
                {
                    start = result.IndexOf(n);
                    Console.WriteLine("Result starts repeating at pos {0}, for a length of {1}.", start, result.Count - start);
                    Console.WriteLine("1/{0} --> 0.{1}", denom, string.Join("", result));
                    return result.Count - start;
                    //break;
                }
                result.Add(n);
                remainders.Add(r);
            }
            return 0;
        }
    }
}
