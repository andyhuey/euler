/*
 * http://projecteuler.net/problem=44
 * Pentagon numbers
 * Answer: 
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
            int ans = 0;
            var sw = Stopwatch.StartNew();
            long s, d;

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
                for (int k = j; k <= seedTo; k++)
                {
                    if (j == k)
                        continue;
                    s = pentagon_nums[j] + pentagon_nums[k];
                    d = pentagon_nums[k] - pentagon_nums[j];
                    //if (j==4 && k==7)
                    //    Console.WriteLine("P({0})={1}, P({2})={3}, D={4}", j, pentagon_nums[j], k, pentagon_nums[k], d);
                    if (isPentagonNum(d) && isPentagonNum(s))
                    {
                        Console.WriteLine("P({0})={1}, P({2})={3}, D={4}", j, pentagon_nums[j], k, pentagon_nums[k], d);
                    }
                }

            sw.Stop();
            Console.WriteLine("elapsed: {0} sec", sw.Elapsed.Seconds);
            return ans;
        }
        
        private long pentagonNum(int n)
        {
            return n * (3 * n - 1) / 2;
        }

        private bool isPentagonNum(long n)
        {
            // do we have it in the list yet?
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
