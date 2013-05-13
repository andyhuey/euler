/*
 * http://projecteuler.net/problem=10
 * Find the sum of all the primes below two million.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Projects1to10
{
    public class Problem10
    {
        
        public long soln1()
        {
            //int loopIterations = 0;
            int nPrimeMax = 2000000;
            int p = 2;
            int sqrt_max = (int)Math.Floor(Math.Sqrt(nPrimeMax));

            var sw = Stopwatch.StartNew();

            bool[] primes = new bool[nPrimeMax];
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

            // sum up the primes
            long ans = 0;
            for (int i = 2; i < nPrimeMax; i++)
            {
                if (primes[i])
                {
                    //Console.WriteLine(i);
                    ans += i;
                }
            }
            
            sw.Stop();
            //Console.WriteLine("Loop iterations: {0:n0}", loopIterations);
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return ans;
        }
    }
}
