/*
 * http://projecteuler.net/problem=70
 * Totient permutation
 * (copied from problem 69.)
 * The answer is 8,319,823.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems70to79
{
    class Problem70
    {
        const int nPrimeMax = 10000000;
        const int MAX_N = 10000000;
        bool[]? primes;

        public long soln1()
        {
            long n_for_min_n_over_phi_n = 0;
            float min_n_over_phi_n = MAX_N;

            List<int>[] primeFactors = new List<int>[MAX_N + 1];

            primes = Utils.getPrimes(nPrimeMax);
            IEnumerable<int> lstPrimes = Enumerable.Range(2, nPrimeMax - 2).Where(x => primes[x]);
            Console.WriteLine("Got {0} primes.", lstPrimes.Count());

            foreach (int n in lstPrimes)
            {
                long n2 = n;
                int i = 1;
                while (n2 <= MAX_N)
                {
                    if (primeFactors[n2] == null)
                        primeFactors[n2] = new List<int>();
                    primeFactors[n2].Add(n);
                    i++;
                    n2 = n * i;
                }
            }
            Console.WriteLine("Done filling in prime factor array.");

            for (int n = 2; n <= MAX_N; n++)
            {
                //float denom = 1;
                float phi_n = n;
                foreach (var p in primeFactors[n])
                    phi_n *= (1 - (float)1 / p);
                
                // only want numbers where phi(n) is a permutation of n.
                if (!isPermutation(n, (long)phi_n))
                    continue;
                
                float n_over_phi_n = (float)n / phi_n;
                if (n_over_phi_n < min_n_over_phi_n)
                {
                    min_n_over_phi_n = n_over_phi_n;
                    n_for_min_n_over_phi_n = n;
                    Console.WriteLine("For n={0}, phi(n)={1} n/phi(n)={2:n6}", n, phi_n, n_over_phi_n);
                }
            }

            return n_for_min_n_over_phi_n;
        }

        private bool isPermutation(long n1, long n2)
        {
            // from problem 52
            List<char> ca1 = new List<char>(n1.ToString());
            List<char> ca2 = new List<char>(n2.ToString());
            if (ca1.Count != ca2.Count)
                return false;
            ca1.Sort();
            ca2.Sort();
            return ca1.SequenceEqual(ca2);
        }
    }
}
