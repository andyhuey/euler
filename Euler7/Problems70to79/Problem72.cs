/*
 * http://projecteuler.net/problem=72
 * Counting Fractions
 * For MAX_D = 8 -> 21; 80 -> 1965; 8000 -> 19,455,781
 * for 100,000 ->  3,039,650,753
 * for 1,000,000 -> The answer is 303,963,552,391 or 303963552391
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
        public int MaxD;
        const int nPrimeMax = 1000000;
        bool[]? primes;

        public static void run()
        {
            var myProblem = new Problem72(1000000);
            var ans = myProblem.soln1();
            Console.WriteLine("The answer for MAX D {0} is {1:n0} or {1}",
                myProblem.MaxD, ans);
        }

        public Problem72(int maxD)
        {
            MaxD = maxD;
        }

        public long soln1()
        {
            long nCount = 0;

            primes = Utils.getPrimes(nPrimeMax);
            IEnumerable<int> lstPrimes = Enumerable.Range(2, nPrimeMax - 2).Where(x => primes[x]);
            Console.WriteLine("Got {0} primes.", lstPrimes.Count());

            List<int>[] primeFactors = new List<int>[MaxD + 1];
            foreach (int n in lstPrimes)
            {
                long n2 = n;
                int i = 1;
                while (n2 <= MaxD)
                {
                    if (primeFactors[n2] == null)
                        primeFactors[n2] = new List<int>();
                    primeFactors[n2].Add(n);
                    i++;
                    n2 = n * i;
                }
            }
            Console.WriteLine("Done filling in prime factor array.");

            long[] totient = new long[MaxD + 1];
            foreach (int p in lstPrimes)
            {
                int k = 1;
                long pk = p;
                while (pk <= MaxD)
                {
                    totient[pk] = pk - (pk / p);
                    //Console.WriteLine("p={0}, pk={1}, phi(pk)={2}", p, pk, totient[pk]);
                    k++;
                    pk = (long)Math.Pow(p, k);
                }
            }

            for (int i = 2; i <= MaxD; i++)
            {
                if (totient[i] == 0)
                {
                    totient[i] = i;
                    foreach (int p in primeFactors[i])
                        totient[i] -= totient[i] / p;
                }
            }

            //for (int i = 0; i <= MAX_D; i++)
            //    Console.WriteLine("phi({0}) = {1}", i, totient[i]);

            nCount = totient.Sum();

            return nCount;
        }
        
        public long soln1_farey_next_term()
        {
            // from http://en.wikipedia.org/wiki/Farey_sequence, 'next term'
            long nCount = 0;
            int a, b, c, d;
            a = 0;
            b = 1;
            c = 1;
            d = MaxD;

            while (c <= MaxD)
            {
                int k = checked((MaxD + b) / d);
                int a1 = c;
                int b1 = d;
                c = checked(k * c - a);
                d = checked(k * d - b);
                a = a1;
                b = b1;
                //Console.Write("{0}/{1}, ", a, b);
                //Console.WriteLine("{0}/{1} [c={2}, d= {3}], ", a, b, c, d);
                nCount++;
                if (nCount % 1000000 == 0)
                    Console.WriteLine("[a={0}, b={1}, c={2}, d={3}] {4:n0} so far...", a, b, c, d, nCount);
            }
            nCount--; // drop 1/1.
            Console.WriteLine();

            return nCount;
        }

        public long soln1_maybe()
        {
            long nCount = 0;

            primes = Utils.getPrimes(nPrimeMax);
            IEnumerable<int> lstPrimes = Enumerable.Range(2, nPrimeMax - 2).Where(x => primes[x]);
            Console.WriteLine("Got {0} primes.", lstPrimes.Count());

            List<int>[] primeFactors = new List<int>[MaxD + 1];
            foreach (int n in lstPrimes)
            {
                long n2 = n;
                int i = 1;
                while (n2 <= MaxD)
                {
                    if (primeFactors[n2] == null)
                        primeFactors[n2] = new List<int>();
                    primeFactors[n2].Add(n);
                    i++;
                    n2 = n * i;
                }
            }
            Console.WriteLine("Done filling in prime factor array.");

            for (int d = 2; d <= MaxD; d++)
            {
                var x = Enumerable.Range(1, d - 1).ToList();
                foreach (int p in primeFactors[d])
                {
                    // remove all prime factors and their multiples.
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
                //if (d % 1000 == 0)
                //    Console.WriteLine("For d={0}, we have {1} fractions.", d, x.Count());
                //Console.WriteLine("For d={0}: {1}", d, string.Join(", ", primeFactors[d]));
            }

            return nCount;
        }

        public long soln1_bf()
        {
            long nCount = 0;

            // initial brute force.
            for (int d = 2; d <= MaxD; d++)
            {
                for (int n = 1; n < d; n++)
                {
                    if (Utils.gcd(n, d) == 1)
                        nCount++;
                }
            }

            return nCount;
        }


    }
}
