/*
 * http://projecteuler.net/problem=9
 * There exists exactly one Pythagorean triplet for which a + b + c = 1000.
 * Find the product abc.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Projects1to10
{
    public class Problem9
    {
        public int soln1()
        {
            int n, m, a = 1, b = 1, c = 1;
            //int targetSum = 12;
            int targetSum = 1000;
            int loopIterations = 0;
            bool foundIt = false;
            var sw = Stopwatch.StartNew();

            n = 2;
            m = 1;
            while (!foundIt)
            {
                while (n > m)
                {
                    loopIterations++;
                    // calc a, b, c
                    a = (n * n) - (m * m);
                    b = 2 * n * m;
                    c = (n * n) + (m * m);
                    Console.WriteLine("a={0}, b={1}, c={2}, sum={3}", a, b, c, a+b+c);
                    //Console.ReadLine();
                    // test
                    if (a + b + c == targetSum)
                    {
                        foundIt = true;
                        Debug.Assert((a * a) + (b * b) == (c * c));
                        //Console.WriteLine("a={0}, b={1}, c={2}", a, b, c);
                        break;
                    }
                    m++;
                }
                n++;
                m = 1;
                Debug.Assert(n < targetSum);
            }

            sw.Stop();
            Console.WriteLine("Loop iterations: {0:n0}", loopIterations);
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return a * b * c;
        }
    }
}
