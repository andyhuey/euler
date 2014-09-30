/*
 * https://projecteuler.net/problem=58
 * Spiral primes
 * (see problem 28)
 * The answer is 26,241
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems50to59
{
    class Problem58
    {
        const int MAX_GRID = 30000;
        Random r;

        public Problem58()
        {
            r = new Random();
        }

        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            // fill in the prime array
            //isPrime(MAX_GRID * MAX_GRID);

            //for (int i = 1; i < 100; i++)
            //{
            //    Console.WriteLine("{0}: {1}", i, isProbablyPrime(i));
            //    if (i % 10 == 0)
            //        Console.ReadLine();
            //}
            //return 0;

            int gridSize = processGrid(MAX_GRID);

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return gridSize;
        }

        private int processGrid(int maxGridSize)
        {
            int nPrimes = 0;
            int nDiagCells = 0;
            int n = 1;

            while (n < maxGridSize)
            {
                if (n == 1)
                {
                    // 1 isn't prime.
                    nDiagCells++;
                    n += 2;
                    continue;
                }
                int[] corner = new int[3];
                corner[0] = n * n - 3 * n + 3;  // upper-right
                corner[1] = n * n - 2 * n + 2;  // upper-left
                corner[2] = n * n - n + 1;      // lower-left
                //corner[3] = n * n;              // lower-right - never prime, of course.
                nDiagCells++;
                foreach (int v in corner)
                {
                    //Console.Write(v);
                    nDiagCells++;
                    if (isPrime(v))
                        nPrimes++;
                }
                double ratio = (double)nPrimes / nDiagCells;
                Console.WriteLine("For grid size {0}, result is {1}/{2} or {3:0}%", n, nPrimes, nDiagCells, ratio * 100);
                //Console.ReadLine();
                if (ratio < 0.10)
                    return n;
                n += 2;
            }

            // we failed...
            return 0;
        }

        private bool isPrime(int n)
        {
            // simple prime test.
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        private bool isProbablyPrime(int n)
        {
            // ** this ain't right. **
            // Miller-Rabin test
            // from http://rosettacode.org/wiki/Miller-Rabin_primality_test#C.23
            // zero and one aren't prime.
            if (n < 2)
                return false;
            // even numbers > 2 aren't prime.
            if (n != 2 && n % 2 == 0)
                return false;
            
            int s = n - 1;
            while (s % 2 == 0)
                s >>= 1;

            int k = n * n;     // I have no idea what this should be...
            for (int i = 0; i < k; i++)
            {
                double a = r.Next((int)n - 1) + 1;
                int temp = s;
                int mod = (int)Math.Pow(a, (double)temp) % n;
                while (temp != n - 1 && mod != 1 && mod != n - 1)
                {
                    mod = (mod * mod) % n;
                    temp = temp * 2;
                }
                if (mod != n - 1 && temp % 2 == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
