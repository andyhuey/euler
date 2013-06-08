/*
 * http://projecteuler.net/problem=20
 * Find the sum of the digits in the number 100!
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Numerics;

namespace Problems20to29
{
    class Problem20
    {
        public long soln1()
        {
            BigInteger biResult = 1;
            var sw = Stopwatch.StartNew();

            for (int i = 100; i >= 1; i--)
                biResult *= i;

            string s = biResult.ToString();
            Console.WriteLine(s);

            long sumOfDigits = 0;
            for (int i = 0; i < s.Length; i++)
                sumOfDigits += Int32.Parse(s.Substring(i, 1));

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);

            return sumOfDigits;
        }
    }
}
