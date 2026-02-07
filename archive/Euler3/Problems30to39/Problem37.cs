/*
 * http://projecteuler.net/problem=37
 * Truncatable primes
 * Find the sum of the only eleven primes that are both truncatable from left to right and right to left.
 * The answer is 748,317.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems30to39
{
    class Problem37
    {
        private List<bool> primes = new List<bool>();
        const int INCR = 1000;

        public Problem37()
        {
            // zero and one aren't prime.
            primes.Add(false);
            primes.Add(false);
        }

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            long sum = 0;
            int count = 0;
            int n = 11;     // start with 11.

            // experimenting with permutations...
            //foreach (int i in getTruncPerms(1234))
            //    Console.WriteLine(i);

            while (count < 11)
            {
                var perms = getTruncPerms(n);
                if (perms.All(x => isPrime(x)))
                {
                    count++;
                    sum += n;
                    Console.WriteLine(n);
                }
                n++;
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return sum;
        }

        // return all L>R and R>L permutations.
        private List<int> getTruncPerms(int n)
        {
            List<int> perms = new List<int>();
            perms.Add(n);
            int d = 10;
            while (d < n)
            {
                perms.Add(n % d);
                perms.Add(n / d);
                d *= 10;
            }
            return perms;
        }

        // copied from problem 27.
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
