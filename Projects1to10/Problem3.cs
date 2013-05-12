/*
 * The prime factors of 13195 are 5, 7, 13 and 29.
 * What is the largest prime factor of the number 600851475143 ?
 * http://projecteuler.net/problem=3
 * 
 * prime factors: 71, 839, 1471, 6857
 * largest prime = 6857
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Projects1to10
{
    class Problem3
    {
        //static int n = 13195;
        static long n = 600851475143;

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("largest prime = {0}", soln1());
        //    Console.WriteLine("largest prime = {0}", soln2());

        //    Console.WriteLine("Press enter...");
        //    Console.ReadLine();

        //}

        private static long soln2()
        {
            // from user 'Unbeliever'
            n = 600851475143;
            long loopIterations = 0;
            long i = 2;
            while (i * i <= n)
            {
                loopIterations++;
                if (n % i == 0)
                    n = n / i;
                else 
                    i++;
            }
            Console.WriteLine("Loop iterations: {0}", loopIterations);  // 1472
            return n;
        }
        
        private static long soln1()
        {
            long loopIterations = 0;
            long i = 2;
            List<long> primeFactors = new List<long>();
            var sw = Stopwatch.StartNew();

            while (n > 1)
            {
                loopIterations++;
                if (n % i == 0)
                {
                    primeFactors.Add(i);
                    n = n / i;
                    i = 2;
                }
                else
                {
                    i++;
                }
            }

            sw.Stop();
            Console.WriteLine("Loop iterations: {0}", loopIterations);  // 9234
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("prime factors: {0}", string.Join<long>(", ", primeFactors));
            return primeFactors.Max();
        }
    }
}
