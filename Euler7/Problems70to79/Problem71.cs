/*
 * http://projecteuler.net/problem=71
 * Ordered Fractions
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems70to79
{
    struct Fraction
    {
        public int n { get; private set; }
        public int d { get; private set; }

        public Fraction(int n, int d)
            : this()
        {
            this.n = n;
            this.d = d;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", n, d);
        }

        public void add_x(int x)
        {
            n += (d * x);
        }

        public void invert()
        {
            int hld = n;
            n = d;
            d = hld;
        }

    }

    class Problem71
    {
        const int MAX_D = 8;
        Dictionary<Tuple<int, int>, int> gcd_cache = new Dictionary<Tuple<int, int>, int>();
        int cache_hits = 0;
        List<Fraction> fracList = new List<Fraction>();

        public long soln1()
        {
            // brute force, for small set.
            for (int d = 2; d <= MAX_D; d++)
            {
                for (int n = 1; n < d; n++)
                {
                    if (gcd(n, d) == 1)
                        fracList.Add(new Fraction(n, d));
                }
            }

            // sort the list.
            foreach (var f in fracList.OrderBy(x => (float)x.n / x.d))
            {
                Console.Write(f);
                Console.Write(", ");
            }
            Console.WriteLine();

            return 0;
        }

        private int gcd(int a, int b)
        {
            // copied from problem 33 (& old ver of p 69).
            // http://en.wikipedia.org/wiki/Greatest_common_divisor
            // Using Euclid's algorithm
            // assuming a & b are > 0.
            //Console.WriteLine("a={0}, b={1}", a, b);
            Tuple<int, int> tkey = new Tuple<int, int>(a, b);
            if (gcd_cache.ContainsKey(tkey))
            {
                cache_hits++;
                return gcd_cache[tkey];
            }

            int rv;
            if (a == b)
                rv = a;
            else if (a > b)
                rv = gcd(a - b, b);
            else
                rv = gcd(a, b - a);

            gcd_cache[tkey] = rv;
            return rv;
        }

    }
}
