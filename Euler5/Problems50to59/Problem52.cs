/*
 * https://projecteuler.net/problem=52
 * Permuted multiples
 * Note: N must be at least 6 digits, and must be divisible by 9.
 * The answer is 142,857
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems50to59
{
    class Problem52
    {
        const int MAX_M = 6;
        const long MAX_N = long.MaxValue / MAX_M;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            long n = 100008;        // first 6-digit # divisible by 9

            while (n < MAX_N)
            {
                int m;
                for (m = 2; m <= MAX_M; m++)
                {
                    if (!isPermutation(n, n * m))
                        break;
                    Console.WriteLine("{0} * {1} = {2}", n, m, n * m);
                }
                if (m > MAX_M)
                    return n;
                n += 9;
            }


            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return 0;
        }

        private bool isPermutation(long n1, long n2)
        {
            // this isn't a terribly efficient way of doing this.
            // some interesting solutions: http://stackoverflow.com/q/3669970/301677 & http://stackoverflow.com/q/50098/301677
            List<char> ca1 = new List<char>(n1.ToString());
            List<char> ca2 = new List<char>(n2.ToString());
            if (ca1.Count != ca2.Count)
                return false;
            ca1.Sort();
            ca2.Sort();
            return ca1.SequenceEqual(ca2);
        }
    }
}
