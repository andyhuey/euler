/*
 * https://projecteuler.net/problem=53
 * Combinatoric selections
 * The answer is 4,075
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problems50to59
{
    class Problem53
    {
        const int C_MAX = 1000000;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            //Console.WriteLine(combinations(5, 3));  // should be 10

            long count = 0;
            for (int n = 1; n <= 100; n++)
            {
                for (int r = 1; r <= n; r++)
                {
                    if (combinations(n, r) > C_MAX)
                    {
                        Console.WriteLine("n={0}, r={1}", n, r);
                        count++;
                    }
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return count;
        }

        private BigInteger combinations(int n, int r)
        {
            // choose r from n
            BigInteger c = factorial(n) / (factorial(r) * factorial(n - r));
            return c;
        }

        private BigInteger factorial(BigInteger n)
        {
            // from problem 15.
            BigInteger rv = 1;
            for (int i = 1; i <= n; i++)
                rv *= i;
            return rv;
            // recursive:
            //if (n <= 1)
            //    return 1;
            //else
            //    return n * factorial(n-1);
        }
    }
}
