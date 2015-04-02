/*
 * http://projecteuler.net/problem=69
 * Totient maximum
 * (brute force: runs out of steam after 2310.)
 * - caching the GCDs doesn't help much.
 * - short-circuiting on n/phi < max doesn't do much either.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems60to69
{
    class Problem69
    {
        const int MAX_N = 1000000;
        Dictionary<Tuple<int, int>, int> gcd_cache = new Dictionary<Tuple<int, int>, int>();

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            int n_for_max_n_over_phi_n = 0;
            float max_n_over_phi_n = 0;

            for (int n = 2; n <= MAX_N; n++)
            {
                List<int> coprimes = new List<int>();
                int phi_n;
                float n_over_phi_n;

                for (int m = 1; m < n; m++)
                {
                    if (gcd(n, m) == 1)
                    {
                        coprimes.Add(m);

                        // n/phi(n) is going to get smaller as we go. if it's < current max, we can give up.
                        phi_n = coprimes.Count();
                        n_over_phi_n = (float)n / phi_n;
                        if (n_over_phi_n < max_n_over_phi_n)
                        {
                            //Console.WriteLine("Breaking on n={0}.", n);
                            break;
                        }
                    }
                }

                phi_n = coprimes.Count();
                n_over_phi_n = (float)n / phi_n;

                if (n_over_phi_n > max_n_over_phi_n)
                {
                    max_n_over_phi_n = n_over_phi_n;
                    n_for_max_n_over_phi_n = n;
                    Console.WriteLine("For n={0}, n/phi(n)={1:n4} [cache size={2}]", n, n_over_phi_n, gcd_cache.Count);
                }

                //Console.WriteLine("For n={0}, coprimes are {1}.", n, string.Join(", ", coprimes));
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);

            return n_for_max_n_over_phi_n;
        }

        private int gcd(int a, int b)
        {
            // copied from problem 33.
            // http://en.wikipedia.org/wiki/Greatest_common_divisor
            // Using Euclid's algorithm
            // assuming a & b are > 0.
            //Console.WriteLine("a={0}, b={1}", a, b);
            Tuple<int, int> tkey = new Tuple<int, int>(a, b);
            if (gcd_cache.ContainsKey(tkey))
                return gcd_cache[tkey];

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
