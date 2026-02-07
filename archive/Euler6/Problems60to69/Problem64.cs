/*
 * https://projecteuler.net/problem=64
 * Odd period square roots
 * The answer is 1322.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems60to69
{
    class Problem64
    {
        public long soln1()
        {
            long rv = 0;
            var sw = Stopwatch.StartNew();
            
            // test: 23, 114
            //this.fractionExpand(13 * 13);

            for (int N = 1; N <= 10000; N++)
            {
                var a = this.fractionExpand(N);
                int period = a.Count() - 1;
                if (period > 0 && isOdd(period))
                    rv++;
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return rv;
        }

        private bool isOdd(int n)
        {
            return n % 2 == 1;
        }

        private List<decimal> fractionExpand(int S)
        {
            // http://en.wikipedia.org/wiki/Methods_of_computing_square_roots#Continued_fraction_expansion
            // S is the number we want a square root of.
            int n = 0;
            List<decimal> m, d, a;
            m = new List<decimal>();
            d = new List<decimal>();
            a = new List<decimal>();
            m.Add(0);
            d.Add(1);
            a.Add(Math.Floor((decimal)Math.Sqrt(S)));
            while (a[n] != a[0] * 2)
            {
                //Console.WriteLine("m={0}, d={1}, a={2}", m[n], d[n], a[n]);
                m.Add(d[n] * a[n] - m[n]);
                d.Add((S - m[n + 1] * m[n + 1]) / d[n]);
                if (d[n + 1] == 0)
                    return a;   // perfect square.
                a.Add(Math.Floor((a[0] + m[n + 1]) / d[n + 1]));
                n++;
            }
            //Console.WriteLine("m={0}, d={1}, a={2}", m[n], d[n], a[n]);
            return a;
        }
    }
}
