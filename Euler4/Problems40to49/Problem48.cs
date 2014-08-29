/*
 * http://projecteuler.net/problem=48
 * Self Powers
 * 1..10: 10,405,071,317
 * The answer is 9110846700.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace Problems40to49
{
    class Problem48
    {
        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            long n = 0;
            BigInteger bigSum = 0;

            for (int i = 1; i <= 1000; i++)
            {
                bigSum += BigInteger.Pow(i, i);
            }
            //n = (long)bigSum;
            n = (long)(bigSum % BigInteger.Pow(10, 10));

            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return n;
        }
    }
}
