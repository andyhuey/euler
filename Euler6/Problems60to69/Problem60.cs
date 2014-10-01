/*
 * https://projecteuler.net/problem=60
 * Prime Pair Sets
 * 13, 5197, 5701, 6733, 8389 -> 26033
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems60to69
{
    class Problem60
    {
        bool[] primes;
        const int nMax = 9999;
        const int nPrimeMax = nMax * nMax;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            getPrimes();
            Console.WriteLine("Got primes...");

            IEnumerable<int> lstPrimes = Enumerable.Range(2, nMax).Where(x => primes[x]);

            //Console.WriteLine(isPrimePairSet(new int[] { 3, 7, 109, 673 }));
            int minSum = nMax * 5;

            foreach (int n1 in lstPrimes)
            {
                foreach (int n2 in lstPrimes.Where(x => x > n1))
                {
                    int[] currSet2 = new int[] { n1, n2 };
                    if (!isPrimePairSet(currSet2))
                        continue;
                    foreach (int n3 in lstPrimes.Where(x => x > n2))
                    {
                        int[] currSet3 = new int[] { n1, n2, n3 };
                        if (!isPrimePairSet(currSet3))
                            continue;
                        foreach (int n4 in lstPrimes.Where(x => x > n3))
                        {
                            int[] currSet4 = new int[] { n1, n2, n3, n4 };
                            if (!isPrimePairSet(currSet4))
                                continue;
                            //Console.WriteLine("{0}, {1}, {2}, {3}", n1, n2, n3, n4);
                            foreach (int n5 in lstPrimes.Where(x => x > n4))
                            {
                                //Console.WriteLine("{0}, {1}, {2}, {3}, {4}", n1, n2, n3, n4, n5);
                                int[] currSet = new int[] { n1, n2, n3, n4, n5 };
                                if (isPrimePairSet(currSet))
                                {
                                    int currSum = n1 + n2 + n3 + n4 + n5;
                                    Console.WriteLine("{0}, {1}, {2}, {3}, {4} -> {5}", n1, n2, n3, n4, n5, currSum);
                                    if (minSum > currSum)
                                        minSum = currSum;
                                }
                            }
                        }
                    }
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return minSum;
        }

        private bool isPrimePairSet(int[] myset)
        {
            for (int i = 0; i < myset.Length; i++)
            {
                if (!isPrime(myset[i]))
                    return false;
                for (int j = i + 1; j < myset.Length; j++)
                {
                    string si = myset[i].ToString();
                    string sj = myset[j].ToString();
                    int ij = Int32.Parse(si + sj);
                    int ji = Int32.Parse(sj + si);
                    if (!isPrime(ij) || !isPrime(ji))
                        return false;
                    //Console.WriteLine("{0}, {1}", ij, ji);
                }
            }
            return true;
        }

        private bool isPrime(int n)
        {
            return primes[n];
        }

        private void getPrimes()
        {
            // get primes
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
