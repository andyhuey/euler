/*
 * http://projecteuler.net/problem=40
 * Champernowne's constant
 * Answer: 
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problems40to49
{
    class Problem40
    {
        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            // let's start with just a string...
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < 10000; i++)
            {
                sb.Append(i);
            }
            Console.WriteLine("sb is {0} digits long", sb.Length);

            //for (int i = 186; i <= 189; i++)
            //    Console.WriteLine(sb[i - 1]);

            for (int i = 1; i < 2890; i++)
            {
                int sbi = sb[i - 1] - (int)'0';
                if (sbi != getChampernowneDigit(i))
                {
                    Console.WriteLine("digit {0}: {1} or {2}?", i, sbi, getChampernowneDigit(i));
                    break;
                }
            }

            //for (int i = 2880; i <= 2889; i++)
            //    Console.WriteLine(getChampernowneDigit(i));

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return 0;

        }

        private int getChampernowneDigit(int dn)
        {
            // to solve the problem, we need to be able to get to d(1,000,000)
            Debug.Assert(dn > 0);
            int d, dr;
            if (dn < 10)
                return dn;
            if (dn < 190)
            {
                d = 10 + (dn - 10) / 2;
                dr = (dn - 10) % 2;
                return d.ToString()[dr] - (int)'0';
            }
            if (dn < 2890)
            {
                d = 100 + (dn - 190) / 3;
                dr = (dn - 190) % 3;
                return d.ToString()[dr] - (int)'0';
            }
            throw new ArgumentOutOfRangeException("dn", "dn is too large.");
        }

        private bool isEven(int i)
        {
            return i % 2 == 0;
        }
    }
}
