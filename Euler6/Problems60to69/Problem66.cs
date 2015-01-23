/*
 * https://projecteuler.net/problem=66
 * Diophantine equation: x^2 – Dy^2 = 1
 * Find the value of D <= 1000 in minimal solutions of x for which the largest value of x is obtained.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems60to69
{
    class Problem66
    {
        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            long x, D;
            long largest_min_x = 0;
            long D_for_largest_min_x = 0;
            double y2;
            bool solnFound;

            for (D = 2; D <= 1000; D++)
            {
                if (isPerfectSquare(D))
                    continue;
                // find minimal solution for x.
                x = 2;
                y2 = 0;
                solnFound = false;
                while (x < 9999 && !solnFound)
                {
                    // we need (x^2 - 1) / D to be a perfect square.
                    y2 = (double)((x * x) - 1) / D;
                    if (isPerfectSquare(y2))
                        solnFound = true;
                    else
                        x++;
                }
                if (!solnFound)
                {
                    Console.WriteLine("Solution not found for D={0}.", D);
                    Console.ReadLine();
                }
                else
                {
                    if (x > largest_min_x)
                    {
                        largest_min_x = x;
                        D_for_largest_min_x = D;
                        Console.WriteLine("For D={0}, min x={1}, y={2}.", D, x, Math.Sqrt(y2));
                    }
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return D_for_largest_min_x;
        }

        private bool isPerfectSquare(long x)
        {
            // http://stackoverflow.com/a/4885965/301677 - won't work for really big numbers.
            double sqrt = Math.Sqrt(x);
            return sqrt % 1 == 0;
        }

        private bool isPerfectSquare(double x)
        {
            double sqrt = Math.Sqrt(x);
            return sqrt % 1 == 0;
        }
    }
}
