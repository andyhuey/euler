/*
 * http://projecteuler.net/problem=41
 * Pandigital prime
 * What is the largest n-digit pandigital prime that exists?
 * The answer is 7,652,413 or 7652413
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems40to49
{
    class Problem41
    {
        // the digits in 987654321 add up to 45, which is divisible by 3, so no 9-digit pandigital # is going to be prime.
        // and the digits in 87654321 add up to 36, which is divisible by 3, so no 8-digit pandigital # is going to be prime.
        const int nMaxPandigital = 7654321;
        const int nPrimeMax = nMaxPandigital + 1;
        bool[] primes;

        public long soln1()
        {
            int ans = 0;
            var sw = Stopwatch.StartNew();

            // takes a while to get so many primes...
            this.getPrimes();

            for (int i = nMaxPandigital; i > 1; i--)
            {
                if (!primes[i])
                    continue;
                // is this prime pandigital?
                if (isPandigital(i))
                {
                    ans = i;
                    break;
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} sec", sw.Elapsed.Seconds);
            return ans;
        }

        private void getPrimes()
        {
            // get primes (from Problem 10)
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

        private bool isPandigital(int n)
        {
            int i;
            string s = Convert.ToString(n);
            bool[] hasOnlyOne = new bool[s.Length + 1];
            hasOnlyOne[0] = true;   // no zeroes allowed.
            foreach (char ch in s)
            {
                i = (int)ch - (int)'0';
                if (i > s.Length)
                    return false;
                if (hasOnlyOne[i])
                    return false;   // already got one...
                hasOnlyOne[i] = true;
            }

            return hasOnlyOne.All(x => x == true);
        }

    }
}
