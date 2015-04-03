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
using System.Numerics;

namespace Problems60to69
{
    class Problem69
    {
        bool[] primes;
        const int nPrimeMax = 1000000;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            long n_for_max_n_over_phi_n = 0;
            float max_n_over_phi_n = 0;

            getPrimes();
            Console.WriteLine("Got primes...");

            IEnumerable<int> lstPrimes = Enumerable.Range(2, nPrimeMax - 2).Where(x => primes[x]);

            foreach (int p in lstPrimes)
            {
                foreach (int q in lstPrimes.Where(x => x > p))
                {
                    //Console.WriteLine("(p={0}, q={1})", p, q);
                    long n;
                    try
                    {
                        n = checked(p * q);
                    }
                    catch (OverflowException)
                    {
                        //Console.WriteLine("(break on p={0}, q={1})", p, q);
                        break;
                    }
                    if (n > nPrimeMax)
                        break;
                    
                    long phi_n = (p - 1) * (q - 1);
                    float n_over_phi_n = (float)n / phi_n;
                    
                    if (n_over_phi_n > max_n_over_phi_n)
                    {
                        max_n_over_phi_n = n_over_phi_n;
                        n_for_max_n_over_phi_n = n;
                        Console.WriteLine("For n={0}, n/phi(n)={1:n4} (p={2}, q={3})", n, n_over_phi_n, p, q);
                    }
                }
            }
                                       
            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);

            return n_for_max_n_over_phi_n;
        }

        
        // prime methods copied from problem 60.
        private bool isPrime(int n)
        {
            return primes[n];
        }

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
