/*
 * http://projecteuler.net/problem=69
 * Totient maximum
 * third try at this...
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problems60to69
{
    class Problem69
    {
        const int MAX_N = 1000000;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            long n_for_max_n_over_phi_n = 0;
            //float max_n_over_phi_n = 0;
            float min_denom = MAX_N;

            for (int n = 2; n <= MAX_N; n++)
            {
                var pn = getPrimeFactors(n).Distinct();
                float denom = 1;
                foreach (var p in pn)
                    denom *= (1 - (float)1 / p);
                //Console.WriteLine("For n={0}, n/phi(n)={1:n2}", n, (float)1/denom);
                // we need to find N with the snallest denominator.
                if (denom < min_denom)
                {
                    min_denom = denom;
                    n_for_max_n_over_phi_n = n;
                    Console.WriteLine("For n={0}, n/phi(n)={1:n2}", n, (float)1/denom);
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);

            return n_for_max_n_over_phi_n;
        }

        // from problem 47.
        public IEnumerable<long> getPrimeFactors(long n)
        {
            long loopIterations = 0;
            long i = 2;
            //List<long> primeFactors = new List<long>();

            while (n > 1)
            {
                loopIterations++;
                if (n % i == 0)
                {
                    //primeFactors.Add(i);
                    yield return i;
                    n = n / i;
                    i = 2;
                }
                else
                {
                    i++;
                }
            }
        }
        
    }
}
