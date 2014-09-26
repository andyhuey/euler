/*
 * https://projecteuler.net/problem=56
 * Powerful digit sum
 * (99,95) -> 972
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
    class Problem56
    {
        public long soln1()
        {
            long nMaxSum = 0;
            var sw = Stopwatch.StartNew();

            for (int a = 1; a < 100; a++)
                for (int b = 1; b < 100; b++)
                {
                    BigInteger pow = BigInteger.Pow(a, b);
                    long sum = sumOfDigits(pow);
                    if (sum > nMaxSum)
                    {
                        nMaxSum = sum;
                        Console.WriteLine("({0},{1}) -> {2}", a, b, sum);
                    }
                }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return nMaxSum;
        }

        private long sumOfDigits(BigInteger n)
        {
            long sum = 0;
            foreach (char ch in n.ToString())
            {
                sum += (int)ch - (int)'0';
            }
            return sum;
        }
    }
}
