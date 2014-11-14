/*
 * https://projecteuler.net/problem=65
 * Convergents of e
 * (See also problems 57 & 64.)
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems60to69
{
    class Problem65
    {
        public long soln1()
        {
            long rv = 0;
            var sw = Stopwatch.StartNew();

            List<int> myContFrac = this.contFracFor_E(10).ToList();
            for (int i=0; i <= 10; i++)
                Console.WriteLine("a[{0}] = {1} ", i, myContFrac[i]);
            Console.WriteLine();
            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return rv;
        }

        private IEnumerable<int> contFracFor_E(int nMax)
        {
            // return elements 0 thru nMax. (might return extra.)
            // see http://oeis.org/A003417
            yield return 2;     // a0
            int k=1, n=1;
            while (n <= nMax)
            {
                yield return 1;
                yield return k * 2;
                yield return 1;
                k++;
                n += 3;
            }
        }
    }
}
