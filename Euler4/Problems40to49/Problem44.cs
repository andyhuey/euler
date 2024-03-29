﻿/*
 * http://projecteuler.net/problem=44
 * Pentagon numbers
 * The answer is 5,482,660 or 5482660
 * P(1020)=1560090, P(2167)=7042750, D=5482660
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems40to49
{
    class Problem44
    {
        List<long> pentagon_nums;
        const int seedTo = 10000;

        public long soln1()
        {
            long diff_min = Int64.MaxValue;
            var sw = Stopwatch.StartNew();
            long s, d;

            //for (int i = 0; i <= 25; i++)
            //    Console.WriteLine("{0}: {1}", i, isPentagonNum(i));
            //return 0;

            // seed the first few.
            Console.WriteLine("Generating the first {0} numbers...", seedTo);
            pentagon_nums = new List<long>();
            for (int i = 0; i <= seedTo; i++)
                pentagon_nums.Add(pentagonNum(i));

            //for (int i = 1; i < 10; i++)
            //    Console.WriteLine(pentagon_nums[i]);

            // let's work through some combinations.
            Console.WriteLine("Working through combinations...");
            for (int j = 1; j <= seedTo; j++)
            {
                if (j % 1000 == 0)
                    Console.WriteLine("j={0}", j);
                for (int k = j; k <= seedTo; k++)
                {
                    if (j == k)
                        continue;
                    s = pentagon_nums[j] + pentagon_nums[k];
                    d = pentagon_nums[k] - pentagon_nums[j];
                    //if (j==4 && k==7)
                    //    Console.WriteLine("P({0})={1}, P({2})={3}, D={4}", j, pentagon_nums[j], k, pentagon_nums[k], d);
                    //if (isPentagonNum(s))
                    //    Console.WriteLine("P({0})={1}, P({2})={3} - sum is a pentagon #.", j, pentagon_nums[j], k, pentagon_nums[k]);
                    //if (isPentagonNum(d))
                    //    Console.WriteLine("P({0})={1}, P({2})={3} - diff is a pentagon #.", j, pentagon_nums[j], k, pentagon_nums[k]);

                    if (isPentagonNum(d) && isPentagonNum(s))
                    {
                        Console.WriteLine("P({0})={1}, P({2})={3}, D={4}", j, pentagon_nums[j], k, pentagon_nums[k], d);
                        diff_min = Math.Min(diff_min, d);
                    }
                }
            }

            // up to 1386 for 1000 checks.
            //Console.WriteLine("We calculated up to p({0}).", pentagon_nums.Count);

            sw.Stop();
            Console.WriteLine("elapsed: {0} sec", sw.Elapsed.Seconds);
            return diff_min;
        }
        
        private long pentagonNum(int n)
        {
            return n * (3 * n - 1) / 2;
        }

        private bool isPentagonNum(long x)
        {
            // from http://www.mathblog.dk/project-euler-44-smallest-pair-pentagonal-numbers/
            double dn = (Math.Sqrt(24 * x + 1) + 1) / 6;
            return dn == (int)dn;
        }

        private bool isPentagonNum_old(long n)
        {
            // do we have it in the list yet?
            if (n > pentagon_nums.Max())
                Console.WriteLine("Generating thru p(n)={0:n0}...", n);
            while (n > pentagon_nums.Max())
            {
                int i = pentagon_nums.Count;
                pentagon_nums.Add(pentagonNum(i));
            }
            // now we do.
            if (pentagon_nums.Any(x => x == n))
                return true;
            return false;
        }
    }
}
