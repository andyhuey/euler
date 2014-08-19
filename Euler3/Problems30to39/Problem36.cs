/*
 * http://projecteuler.net/problem=36
 * Double-base palindromes
 * Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
 * The answer is 872,187
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems30to39
{
    class Problem36
    {
        const int nMax = 1000000;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            long sum = 0;

            //Console.WriteLine(isPalindrome(585));

            for (int i = 1; i <= nMax; i++)
            {
                if (isPalindrome(i))
                {
                    Console.WriteLine(i);
                    sum += i;
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return sum;
        }

        static bool isPalindrome(int n)
        {
            string s10 = n.ToString();
            string s2 = Convert.ToString(n, 2);

            return s10.Equals(s10.ReverseString()) && s2.Equals(s2.ReverseString());
        }
    }

    public static class MyExtensions
    {
        /// <summary>
        /// Receives string and returns the string with its letters reversed.
        /// http://www.dotnetperls.com/reverse-string
        /// see also: http://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
        /// </summary>
        public static string ReverseString(this string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
