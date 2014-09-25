/*
 * https://projecteuler.net/problem=53
 * Combinatoric selections
 * see http://en.wikipedia.org/wiki/Binomial_coefficient
 * The answer is 4,075
 * < 1 sec for the BigInteger solution w/factorials.
 * 17 sec for the original recursive solution.
 * < 1 sec for the revised recursive solution.
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
        Dictionary<Tuple<int, int>, long> comboVal = new Dictionary<Tuple<int, int>, long>();

        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            //Console.WriteLine(combinations(5, 3));  // should be 10

            long count = 0;
            for (int n = 1; n <= 100; n++)
            {
                for (int r = 1; r <= n; r++)
                {
                    BigInteger c = combinations(n, r);
                    if (c > C_MAX)
                    {
                        Console.WriteLine("n={0}, r={1} -> {2}", n, r, c);
                        count++;
                    }
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} sec", sw.Elapsed.Seconds);
            return count;
        }

        private long combinations(int n, int k)
        {
            // n choose k, recursive, but short-circuit when > 1,000,000
            var key = Tuple.Create(n, k);
            if (comboVal.ContainsKey(key))
                return comboVal[key];
            if (k == 0 || n == k)
            {
                comboVal[key] = 1;
                return 1;
            }
            long left = combinations(n - 1, k - 1);
            long right = combinations(n - 1, k);
            if (left > C_MAX || right > C_MAX)
            {
                comboVal[key] = C_MAX + 1;
                return C_MAX + 1;
            }
            comboVal[key] = left + right;
            return left + right;
        }

        //private BigInteger combinations(int n, int r)
        //{
        //    // brute force: choose r from n
        //    BigInteger c = factorial(n) / (factorial(r) * factorial(n - r));
        //    return c;
        //}

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
