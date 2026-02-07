/*
 * http://projecteuler.net/problem=40
 * Champernowne's constant
 * Answer: 210
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

            int ans = getChampernowneDigit(1)
                * getChampernowneDigit(10)
                * getChampernowneDigit(100)
                * getChampernowneDigit(1000)
                * getChampernowneDigit(10000)
                * getChampernowneDigit(100000)
                * getChampernowneDigit(1000000);

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return ans;
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
            if (dn < 38890)
            {
                d = 1000 + (dn - 2890) / 4;
                dr = (dn - 2890) % 4;
                return d.ToString()[dr] - (int)'0';
            }
            if (dn < 488890)
            {
                d = 10000 + (dn - 38890) / 5;
                dr = (dn - 38890) % 5;
                return d.ToString()[dr] - (int)'0';
            }
            if (dn < 5888890)
            {
                d = 100000 + (dn - 488890) / 6;
                dr = (dn - 488890) % 6;
                return d.ToString()[dr] - (int)'0';
            }
            throw new ArgumentOutOfRangeException("dn", "dn is too large.");
        }

    }
}
