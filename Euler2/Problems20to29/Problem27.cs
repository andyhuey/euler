/*
 * http://projecteuler.net/problem=27
 * Quadratic primes
 * The answer is -59,231
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
            // known equations:
            //Console.WriteLine("n2 + n + 41 produces {0} primes.", howManyPrimes(1, 41));
            //Console.WriteLine("n2 - 79n + 1601 produces {0} primes.", howManyPrimes(-79, 1601));

            int nMaxPrimes = 0;
            int nMaxA = 0, nMaxB = 0;

            for (int a = -999; a < 1000; a++)
                for (int b = 0; b < 1000; b++)
                {
                    // don't bother if b isn't prime.
                    if (!isPrime(b))
                        continue;
                    // try it out...
                    int nPrimes = howManyPrimes(a, b);
                    if (nPrimes > nMaxPrimes)
                    {
                        Console.WriteLine("a={0}, b={1} produces {2} primes.", a, b, nPrimes);
                        nMaxPrimes = nPrimes;
                        nMaxA = a;
                        nMaxB = b;
                    }
                }
            return nMaxA * nMaxB;
        }

        private int howManyPrimes(int a, int b)
        {
            int n = 0;
            while (isPrime(evalQuadEq(n, a, b)))
                n++;
            return n;
        }

        private int evalQuadEq(int n, int a, int b)
        {
            return (n * n) + (a * n) + b;
        }

        private bool isPrime(int n)
        {
            if (n < 0)
                return false;

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
