/*
 * http://projecteuler.net/problem=72
 * Counting Fractions
 * For MAX_D = 8 -> 21; 80 -> 1965; 8000 -> 19,455,781
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems70to79
{
    class Problem72
    {
        const int nPrimeMax = 1000000;
        bool[] primes;

        const int MAX_D = 8000; //1000000;

        public long soln1()
        {
            long nCount = 0;

            getPrimes();
            IEnumerable<int> lstPrimes = Enumerable.Range(2, nPrimeMax - 2).Where(x => primes[x]);
            Console.WriteLine("Got {0} primes.", lstPrimes.Count());

            List<int>[] primeFactors = new List<int>[MAX_D + 1];
            foreach (int n in lstPrimes)
            {
                long n2 = n;
                int i = 1;
                while (n2 <= MAX_D)
                {
                    if (primeFactors[n2] == null)
                        primeFactors[n2] = new List<int>();
                    primeFactors[n2].Add(n);
                    i++;
                    n2 = n * i;
                }
            }
            Console.WriteLine("Done filling in prime factor array.");

            for (int d = 2; d <= MAX_D; d++)
            {
                var x = Enumerable.Range(1, d - 1).ToList();
                foreach (int p in primeFactors[d])
                {
                    int p2 = p;
                    int i = 1;
                    while (p2 < d)
                    {
                        x.Remove(p2);
                        i++;
                        p2 = p * i;
                    }
                }
                nCount += x.Count();
                //Console.WriteLine("For d={0}, we have {1} fractions.", d, x.Count());
                //Console.WriteLine("For d={0}: {1}", d, string.Join(", ", primeFactors[d]));
            }

            return nCount;
        }

        public long soln1_bf()
        {
            long nCount = 0;

            // initial brute force.
            for (int d = 2; d <= MAX_D; d++)
            {
                for (int n = 1; n < d; n++)
                {
                    if (gcd(n, d) == 1)
                        nCount++;
                }
            }

            return nCount;
        }

        // prime method copied from problem 70.
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

        private void swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        private int gcd(int a, int b)
        {
            // http://en.wikipedia.org/wiki/Greatest_common_divisor
            // assuming a & b are > 0.
            //Console.Write("a={0}, b={1} ", a, b);
            int r;
            if (a > b)
                swap(ref a, ref b);

            while (b != 0)
            {
                r = a % b;
                a = b;
                b = r;
            }
            //Console.WriteLine(" --> {0}", a);
            return a;
        }
    }
}
