/*
 * https://projecteuler.net/problem=61
 * Cyclical figurate numbers
 * (see also problem 45)
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems60to69
{
    class Problem61
    {
        struct FigurateNum
        {
            public int num { get; private set; }
            public bool isTriangleNum { get; set; }
            public bool isSquareNum { get; set; }
            public bool isPentagonNum { get; set; }
            public bool isHexagonNum { get; set; }
            public bool isHeptagonNum { get; set; }
            public bool isOctagonNum { get; set; }

            public FigurateNum(int n)
                : this()
            {
                this.num = n;
            }
        }

        public long soln1()
        {
            var sw = Stopwatch.StartNew();


            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return 0;
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

        private long squareNum(int n)
        {
            return n * n;
        }

        private bool isSquareNum(long n)
        {
            double dn = Math.Sqrt(n);
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

        private long heptagonNum(int n)
        {
            return n * (5 * n - 3) / 2;
        }

        private long octagonNum(int n)
        {
            return n * (3 * n - 2);
        }
    }
}
