/*
 * http://projecteuler.net/problem=50
 * consecutive prime sum
 * for max=100: 6 terms add up to 41.
 * for max=1000: 21 terms add up to 953.
 * for max=1,000,000: 543 terms add up to 997651.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems50to59
{
    class Problem50
    {
        const int nPrimeMax = 1000000;
        bool[] primes;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            long nLenMaxRun = 0;
            long nSumMaxRun = 0;
            
            this.getPrimes();
            List<int> lstPrimes = Enumerable.Range(2, nPrimeMax-2).Where(x => primes[x]).ToList();
            Console.WriteLine("There are {0} primes in our list.", lstPrimes.Count);

            for (int i = 0; i < lstPrimes.Count; i++)
            {
                int nLenRun = 0;
                int nSum = 0;
                int j = i;
                while (nSum < nPrimeMax && j < lstPrimes.Count)
                {
                    if (isPrime(nSum) && nLenRun > nLenMaxRun)
                    {
                        nLenMaxRun = nLenRun;
                        nSumMaxRun = nSum;
                        Console.WriteLine("New sum: {0} terms add up to {1}.", nLenMaxRun, nSumMaxRun);
                    }
                    nSum += lstPrimes[j++];
                    nLenRun++;
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return nSumMaxRun;
        }

        private bool isPrime(int n)
        {
            return primes[n];
        }

        private void getPrimes()
        {
            // get primes (from Problems 10 & 49)
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
