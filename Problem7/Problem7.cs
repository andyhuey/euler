/*
 * http://projecteuler.net/problem=7
 * By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
 * What is the 10 001st prime number?
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem7
{
    class Problem7
    {
        static void Main(string[] args)
        {
            Console.WriteLine("the answer is {0:n0}", soln1());

            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }
        
        static long soln1()
        {
            // borrowing a bit from http://stackoverflow.com/a/3745785/301677
            //int loopIterations = 0;
            int nPrimeToFind = 10001;
            List<long> primes = new List<long> { 2 };
            long i = 3;
            long sqrt_i;
            bool isPrime;
            
            var sw = Stopwatch.StartNew();

            while (primes.Count < nPrimeToFind)
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
                    primes.Add(i);
                    //Console.WriteLine("Found prime {0}: {1:n0}", primes.Count, i);
                }
                i++;
                //i += 2;     // skip even #s -- doesn't really speed anything up...
            }

            sw.Stop();
            //Console.WriteLine("Loop iterations: {0:n0}", loopIterations);
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return primes.Last();
        }
    }
}
