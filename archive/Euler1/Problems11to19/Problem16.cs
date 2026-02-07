/*
 * http://projecteuler.net/problem=16
 * What is the sum of the digits of the number 2^1000?
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Numerics;

namespace Problems11to19
{
    class Problem16
    {
        int max_power = 1000;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            int pow;
            List<int> value = new List<int>() { 2 };

            for (pow = 2; pow <= max_power; pow++)
            {
                doubleIt(value);
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);

            return value.Sum();
        }

        void doubleIt(List<int> value)
        {
            int sum;
            int carry = 0;

            for (int i = 0; i < value.Count; i++)
            {
                sum = value[i] + value[i] + carry;
                carry = 0;
                if (sum >= 10)
                {
                    carry = 1;
                    sum -= 10;
                }
                value[i] = sum;
            }

            if (carry > 0)
                value.Add(carry);
        }

        public long soln2()
        {
            // simple with BigInts.
            BigInteger n = 1;
            long sum = 0;
            string result;

            result = (n << 1000).ToString();

            for (int i = 0; i < result.Length; i++)
            {
                sum += Int32.Parse(result.Substring(i, 1));
            }
            return sum;
        }
    }
}
