/*
 * http://projecteuler.net/problem=45
 * Triangular, pentagonal, and hexagonal
 * (got up to 200,000,000 without hitting it.)
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems40to49
{
    class Problem45
    {
        const int startAt = 285 + 1;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            int i = startAt;
            bool found = false;
            long t;
            do
            {
                t = triangleNum(i);
                if (isPentagonNum(t) && isHexagonNum(t))
                {
                    Console.WriteLine("T{0}={1} is T, P, and H.", i, t);
                    found = true;
                }
                if (i % 10000 == 0)
                    Console.WriteLine("i={0:n0}", i);
                i++;
            } while (!found);

            sw.Stop();
            Console.WriteLine("elapsed: {0} sec", sw.Elapsed.Seconds);
            return t;
        }
        private long triangleNum(int n)
        {
            return n * (n + 1) / 2;
        }

        private bool isTriangleNum(int x)
        {
            // from http://www.mathblog.dk/project-euler-42-triangle-words/
            double dn = (Math.Sqrt(8 * x + 1) - 1) / 2;
            return dn == (int)dn;
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

        private long hexagonNum(int n)
        {
            return n * (2 * n - 1);
        }

        private bool isHexagonNum(long x)
        {
            // from http://en.wikipedia.org/wiki/Hexagonal_number
            double dn = (Math.Sqrt(8 * x + 1) + 1) / 4;
            return dn == (int)dn;
        }
    
    }
}
