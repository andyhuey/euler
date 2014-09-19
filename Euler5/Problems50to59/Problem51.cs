/*
 * http://projecteuler.net/problem=51
 * 
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems50to59
{
    class Problem51
    {
        private List<bool> primes = new List<bool>();
        const int INCR = 1000;
        const int nMin = 56003;

        public Problem51()
        {
            // zero and one aren't prime.
            primes.Add(false);
            primes.Add(false);
        }

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            
            int n = nMin;
            while (true)
            {
                // do stuff
                string nStr = Convert.ToString(n);
                for (int digit = 0; digit <= 2; digit++)
                {
                    //string nStrNext = nStr.Replace(
                }
                n = getNextPrime(n);
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return n;
        }

        private int getNextPrime(int n)
        {
            while (!isPrime(++n)) ;
            return n;
        }

        // copied from problems 37 & 46.
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
