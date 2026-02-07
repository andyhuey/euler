/*
 * http://projecteuler.net/problem=47
 * Distinct prime factors
 * Find the first four consecutive integers to have four distinct prime factors.
 * The answer is 134,043.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems40to49
{
    class Problem47
    {
        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            long ans = 0;
            long n = 210;           // 210 = 2x3x5x7
            long run = 0;
            var allPrimeFactors = new List<long>();

            // 644 -> 2x2x7x23 -> 4x7x23
            //var q = getPrimeFactors(644).GroupBy(x => x).Select(x => x.Key * x.Count());
            //foreach (var n in q) Console.WriteLine(n);

            //for (n = 134043; n <= 134047; n++)
            //{
            //    Console.Write("n={0}: ", n);
            //    var q = getPrimeFactors(n).GroupBy(x => x).Select(x => x.Key * x.Count());
            //    foreach (var x in q) Console.Write("{0} ", x);
            //    Console.Write("\n");
            //}
            //return 0;
            //n = 134000;

            while (run < 4)
            {
                if (run >= 3)
                    Console.WriteLine("Run={0} with n={1}.", run, n);

                // get the distinct prime factors for n.
                var distPrimeFact = getPrimeFactors(n).GroupBy(x => x).Select(x => x.Key * x.Count());

                // must have 4 distinct prime factors, and must be distinct from previous.
                if (distPrimeFact.Count() != 4 || allPrimeFactors.Intersect(distPrimeFact).Any())
                {
                    run = 0; 
                    n++;
                    allPrimeFactors = new List<long>();
                    continue;
                }
                // distinct so far.
                run++;
                n++;
                allPrimeFactors.Concat(distPrimeFact);
            }

            ans = n - 4;    // (we want the first one.)

            sw.Stop();
            Console.WriteLine("elapsed: {0} sec", sw.Elapsed.Seconds);
            return ans;
        }

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
