/*
 * http://projecteuler.net/problem=5
 * 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
 * What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("the answer is {0}", soln1());

            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        static long soln1()
        {
            int loopIterations = 0;
            long ans = 2520;
            long bestSoFar = 1;  // for fun
            bool foundIt = false;

            var sw = Stopwatch.StartNew();

            while (!foundIt)
            {
                loopIterations++;
                long i;
                for (i = 1; i <= 20; i++)
                {
                    if (ans % i != 0)
                        break;
                }
                i--;
                if (i > bestSoFar)
                {
                    Console.WriteLine("{0:n0} can be divided by 1 thru {1}", ans, i);
                    bestSoFar = i;
                }
                if (i >= 20)
                    foundIt = true;
                else
                    ans++;
            }

            sw.Stop();
            Console.WriteLine("Loop iterations: {0}", loopIterations);  // 9234
            Console.WriteLine("elapsed: {0} sec", sw.Elapsed.TotalSeconds);
            return ans;
        }
    }
}
