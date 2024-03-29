﻿/*
 * https://projecteuler.net/problem=58
 * Spiral primes
 * (see problem 28)
 * The answer is 26,241
 */
using System;
using System.Collections;
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

        public long soln1()
        {
            var sw = Stopwatch.StartNew();

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
                //Console.WriteLine("For grid size {0}, result is {1}/{2} or {3:0}%", n, nPrimes, nDiagCells, ratio * 100);
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

        // solution below is from user skyivair, 15 May 2014.
        // (using a sieve actually takes longer than just checking one at a time.)
        const int N = 30001;
        static BitArray primes;

        public long soln2()
        {
            var sw = Stopwatch.StartNew();

            PrimeSieve(MAX_GRID * MAX_GRID);
            int gridSize = SpiralCalc();

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return gridSize;
        }

        private void PrimeSieve(int n)
        {
            primes = new BitArray(n + 1, true);
            primes[0] = primes[1] = false;
            int m = (int)Math.Sqrt(n);
            for (int i = 2; i <= m; i++)
                if (primes[i])
                    for (int k = i << 1; k <= n; k += i)
                        primes[k] = false;
        }

      private int SpiralCalc()
      {
          for (int n = 0, i = 1, k = 2; ; i += k, k += 2)
          {
              if (primes[i += k]) n++;
              if (primes[i += k]) n++;
              if (primes[i += k]) n++;
              if (n * 5 <= k) return k + 1;
          }
      }
    }
}
