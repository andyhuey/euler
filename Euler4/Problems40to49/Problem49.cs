/*
 * http://projecteuler.net/problem=49
 * Prime Permutations
 * We got it: 1487, 4817, 8147
 * We got it: 2969, 6299, 9629
 * The answer is 296,962,999,629 or 296962999629
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems40to49
{
    class Problem49
    {
        int nPrimeMax = 10000;  // we need all 4-digit primes.
        bool[] primes;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            long n = 0;

            //Console.WriteLine(this.isPermutation(1234, 2341));

            this.getPrimes();
            List<int> lstPrimes = Enumerable.Range(1001, 8998).Where(x => primes[x]).ToList();

            foreach (int i in lstPrimes)
            {
                foreach (int j in lstPrimes.Where(x => x > i))
                {
                    if (!primes[j])
                        continue;
                    if (isPermutation(i, j))
                    {
                        //Console.WriteLine("{0} & {1} are prime permutations.", i, j);
                        int d = j - i;
                        int k = j + d;
                        if (k < nPrimeMax && primes[k] && isPermutation(j, k))
                        {
                            Console.WriteLine("We got it: {0}, {1}, {2}", i, j, k);
                            n = Convert.ToInt64(string.Format("{0}{1}{2}", i, j, k));
                        }
                    }
                }
            }

            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return n;
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

        private bool isPermutation(int n1, int n2)
        {
            // not sure if I'll need this, but...
            HashSet<char> hs1 = new HashSet<char>(n1.ToString());
            HashSet<char> hs2 = new HashSet<char>(n2.ToString());

            return hs1.SetEquals(hs2);
        }

    }
}
