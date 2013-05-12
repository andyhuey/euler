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
            long nPrimeMax = 2000000;
            List<long> primes = new List<long> { 2 };
            long i = 3;
            long sqrt_i;
            bool isPrime;
            bool isDone = false;

            var sw = Stopwatch.StartNew();

            while (!isDone)
            {
                sqrt_i = (long)Math.Floor(Math.Sqrt(i));
                isPrime = true;
                foreach (var p in primes)
                {
                    if (i % p == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    if (p > sqrt_i) // this helps a lot.
                        break;
                }
                if (isPrime)
                {
                    if (i >= nPrimeMax)
                        isDone = true;
                    else
                    {
                        primes.Add(i);
                        //Console.WriteLine("Found prime {0}: {1:n0}", primes.Count, i);
                    }
                }
                i++;
                //i += 2;     // skip even #s -- doesn't really speed anything up...
            }

            sw.Stop();
            //Console.WriteLine("Loop iterations: {0:n0}", loopIterations);
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return primes.Sum();
        }
    }
}
