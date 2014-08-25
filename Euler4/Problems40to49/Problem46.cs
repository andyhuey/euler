/*
 * http://projecteuler.net/problem=46
 * Goldbach's other conjecture
 * What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?
 * 
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems40to49
{
    class Problem46
    {
        private List<bool> primes = new List<bool>();
        const int INCR = 1000;

        public Problem46()
        {
            // zero and one aren't prime.
            primes.Add(false);
            primes.Add(false);
        }

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            int ans = 0;

            // start at 9 (= 7 + 2 * 1^2)
            int nCandidate = 9;
            while (true)
            {
                int nPrime = 2;
                if (isSquare((nCandidate - nPrime) / 2))
                {
                    ans = nCandidate;
                    break;
                }
                // try next prime that's < nCandidate.
                nPrime = getNextPrime(nPrime);

                // if no more primes to try, nCandidate = next odd composite #.
                if (nPrime >= nCandidate)
                {
                    nPrime = 2;
                    nCandidate = getNextCandidate(nCandidate);
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} sec", sw.Elapsed.Seconds);
            return ans;
        }

        private bool isSquare(int n)
        {
            return Math.Sqrt(n) == n;
        }

        private int getNextPrime(int n)
        {
            while (!isPrime(++n)) ;
            return n;
        }

        private int getNextCandidate(int nCandidate)
        {
            // return the next odd composite #.
            throw new NotImplementedException();
        }

        // copied from problem 37.
        private bool isPrime(int n)
        {
            if (n < 0)
                return false;

            int nOldMax = this.primes.Count();
            if (n < nOldMax)
                return this.primes[n];

            int p = 2;      // NOTE: we shouldn't always start at 2. I'm repeating work I've already done...
            int nPrimeMax = nOldMax + INCR;
            int sqrt_max = (int)Math.Floor(Math.Sqrt(nPrimeMax));

            //Console.WriteLine("Filling in primes from {0} to {1}.", nOldMax, nPrimeMax);

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
