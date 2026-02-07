/*
 * https://projecteuler.net/problem=51
 * Prime digit replacements
 * The answer is 121,313.
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
                int p = getPrimePerms(n);

                if (p >= 8)
                    break;      // we got it.
                
                n = getNextPrime(n);
                
                //if (n > nMin + 100)
                //    break;
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return n;
        }

        private int getPrimePerms(int n)
        {
            // get the set of all digits in n.
            string nStr = Convert.ToString(n);
            //HashSet<char> digitsOfN = new HashSet<char>(nStr.ToCharArray());
            //Console.WriteLine("n={0}: set={1}", n, string.Join<char>(",", digitsOfN));

            int nPrimesFoundMax = 0;
            for (char digit = '0'; digit <= '2'; digit++)
            {
                // do we have this digit?
                if (!nStr.Contains(digit))
                    continue;
                // if so, replace & test.
                int nPrimesFound = 0;
                for (char nextDigit = (char)(digit + 1); nextDigit <= '9'; nextDigit++)
                {
                    string nStrNext = nStr.Replace(digit, nextDigit);
                    if (isPrime(Int32.Parse(nStrNext)))
                        nPrimesFound++;
                }
                if (nPrimesFound > 5)
                    Console.WriteLine("Found {0} primes for n={1}, digit={2}", nPrimesFound, n, digit);
                if (nPrimesFound > nPrimesFoundMax)
                    nPrimesFoundMax = nPrimesFound;
            }
            return nPrimesFoundMax + 1;     // count the original # too.
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
            int nPrimeMax = nOldMax;
            do {
                nPrimeMax += INCR;
            } while (nPrimeMax < n);

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
