/*
 * http://projecteuler.net/problem=27
 * Quadratic primes
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems20to29
{
    class Problem27
    {
        private List<bool> primes = new List<bool>();
        const int INCR = 1000;

        public Problem27()
        {
            // zero and one aren't prime.
            primes.Add(false);
            primes.Add(false);
        }

        public long soln1()
        {
            //var sw = Stopwatch.StartNew();
            for (int i = 3; i < 1200; i += 17)
                Console.WriteLine("Is {0} prime? - {1}", i, this.isPrime(i));
            return 0;
        }

        private bool isPrime(int n)
        {
            int nOldMax = this.primes.Count();
            if (n < nOldMax)
                return this.primes[n];

            int p = 2;
            int nPrimeMax = nOldMax + INCR;
            int sqrt_max = (int)Math.Floor(Math.Sqrt(nPrimeMax));

            Console.WriteLine("Filling in primes from {0} to {1}.", nOldMax, nPrimeMax);

            for (int i = nOldMax; i < nPrimeMax; i++)
                primes.Add(true);

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
            // now, check the number we asked for.
            return primes[n];
        }
    }
}
