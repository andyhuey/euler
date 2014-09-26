/*
 * https://projecteuler.net/problem=55
 * Lychrel numbers
 * The answer is 249.
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
    class Problem55
    {
        const int NMAX = 10000;
        const int ITER_MAX = 50;

        public long soln1()
        {
            long nfound = 0;
            var sw = Stopwatch.StartNew();

            //Console.WriteLine(isLychrel(121));  // false
            //Console.WriteLine(isLychrel(349));  // false
            //Console.WriteLine(isLychrel(394));  // true

            for (long n = 1; n < NMAX; n++)
            {
                if (isLychrel(n))
                {
                    Console.WriteLine("Found: {0}", n);
                    nfound++;
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return nfound;
        }

        private bool isLychrel(long n)
        {
            int iter = 0;
            BigInteger cur_n = n;
            BigInteger sum;
            while (iter++ < ITER_MAX)
            {
                sum = cur_n + getReverse(cur_n);
                //Console.WriteLine("{0}: {1} + {2} = {3}", iter, cur_n, getReverse(cur_n), sum);
                //Console.ReadLine();
                if (isPalindrome(sum))
                    return false;
                cur_n = sum;
            }
            // if we fall out of the loop, we got one.
            return true;
        }

        // not really any faster than doing it with strings.
        //static BigInteger getReverse(BigInteger n)
        //{
        //    BigInteger rev = 0;
        //    BigInteger num = n;
        //    while (num != 0)
        //    {
        //        rev *= 10;
        //        rev += num % 10;
        //        num /= 10;
        //    }
        //    return rev;
        //}

        static BigInteger getReverse(BigInteger n)
        {
            return BigInteger.Parse(n.ToString().ReverseString());
        }

        static bool isPalindrome(BigInteger n)
        {
            //return n.Equals(getReverse(n));
            string s = n.ToString();
            return s.Equals(s.ReverseString());
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
