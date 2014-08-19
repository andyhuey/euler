/*
 * http://projecteuler.net/problem=39
 * Integer right triangles
 * Answer: 840
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems30to39
{
    class Problem39
    {
        const int max_p = 1000;

        struct Triangle
        {
            public int a { get; private set; }
            public int b { get; private set; }
            public int c { get; private set; }

            public Triangle(int a, int b, int c) : this()
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }

            public override string ToString()
            {
                return string.Format("({0}, {1}, {2})", a, b, c);
            }

        }

        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            // we're going to keep a list of 'p' values, with all valid triangles.
            Dictionary<int, List<Triangle>> results = new Dictionary<int, List<Triangle>>();
            for (int i=1; i <= max_p; i++)
                results.Add(i, new List<Triangle>());

            for (int a = 1; a < max_p; a++)
                for (int b = a; b < max_p; b++)
                {
                    if (a + b >= max_p)
                        continue;
                    double c = Math.Sqrt((a * a) + (b * b));
                    if (c != Math.Floor(c))     // must be a whole #.
                        continue;
                    if (c < 1)                  // zero doesn't count.
                        continue;
                    int c1 = Convert.ToInt32(c);
                    int p = a + b + c1;
                    if (p > max_p)
                        continue;

                    Triangle t = new Triangle(a, b, c1);
                    results[p].Add(t);
                    Console.WriteLine("p={0}: {1}", p, t);
                }

            int best_p = results.OrderByDescending(r => r.Value.Count()).First().Key;

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return best_p;
        }
    }
}
