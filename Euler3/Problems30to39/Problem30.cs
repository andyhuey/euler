/*
 * http://projecteuler.net/problem=30
 * Digit fifth powers
 * 
 * Found: 4150
 * Found: 4151
 * Found: 54748
 * Found: 92727
 * Found: 93084
 * Found: 194979
 * The answer is 443,839
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems30to39
{
    class Problem30
    {
        public long soln1()
        {
            // my solution
            long sumOfNumbers = 0;
            for (long i = 10; i < Math.Pow(9, 5) * 6; i++)
            {
                string s = i.ToString();
                long sumOfPowers = 0;
                for (int ci = 0; ci < s.Length; ci++)
                {
                    sumOfPowers += (long)Math.Pow(Double.Parse(s.Substring(ci,1)), 5);
                }
                if (sumOfPowers == i)
                {
                    Console.WriteLine("Found: {0}", i);
                    sumOfNumbers += sumOfPowers;
                }
            }
            return sumOfNumbers;
        }

        public long soln2()
        {
            // from user adamsonic, 03 Apr 2014
            return Enumerable.Range(2, 500000).Where(
                t => t == t.ToString().ToArray().Select(
                    digit => int.Parse(digit.ToString())).Aggregate(
                    0, (acc, num) => acc + (int)Math.Pow(num, 5))).Sum();
        }
    }
}
