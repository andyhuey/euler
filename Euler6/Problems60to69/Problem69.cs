/*
 * http://projecteuler.net/problem=69
 * Totient maximum
 * The answer is 510510.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problems60to69
{
    class Problem69
    {
        const int nPrimeMax = 1000000;
        const int MAX_N = 1000000;
        bool[] primes;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            long n_for_max_n_over_phi_n = 0;
            float min_denom = MAX_N;

            List<int>[] primeFactors = new List<int>[MAX_N+1];

            getPrimes();
            IEnumerable<int> lstPrimes = Enumerable.Range(2, nPrimeMax - 2).Where(x => primes[x]);
            Console.WriteLine("Got {0} primes.", lstPrimes.Count());

            // simplest solution: just multiply primes together and take the largest # under 1,000,000.
            //long prod = 1;
            //foreach (int n in lstPrimes)
            //{
            //    if (prod * n > MAX_N)
            //        break;
            //    prod *= n;
            //}
            //return prod;
            
            foreach (int n in lstPrimes)
            {
                long n2 = n;
                int i = 1;
                while (n2 <= MAX_N)
                {
                    if (primeFactors[n2] == null)
                        primeFactors[n2] = new List<int>();
                    primeFactors[n2].Add(n);
                    i++;
                    n2 = n * i;
                }
            }
            Console.WriteLine("Done filling in prime factor array.");

            for (int n = 2; n <= MAX_N; n++)
            {
                float denom = 1;
                foreach (var p in primeFactors[n])
                    denom *= (1 - (float)1 / p);
                // we need to find N with the snallest denominator.
                if (denom < min_denom)
                {
                    min_denom = denom;
                    n_for_max_n_over_phi_n = n;
                    Console.WriteLine("For n={0}, n/phi(n)={1:n2}", n, (float)1 / denom);
                }
                //Console.WriteLine("Prime factors of {0} are: {1}", n, string.Join(", ", primeFactors[n]));
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);

            return n_for_max_n_over_phi_n;
        }

        // prime method copied from problem 60.
        private void getPrimes()
        {
            // get primes
            primes = new bool[nPrimeMax];
            int p = 2;
            int sqrt_max = (int)Math.Floor(Math.Sqrt(nPrimeMax));

            // initialize all to true
            for (int i = 2; i < nPrimeMax; i++)
                primes[i] = true;

            while (p <= sqrt_max)
            {
                // cross out all the multiple of p.
                for (int i = p * p; i < nPrimeMax; i += p)
                {
                    primes[i] = false;
                }

                // get the next p.
                do
                {
                    p++;
                } while (!primes[p]);
            }
        }
    }
}
