/*
 * https://projecteuler.net/problem=65
 * Convergents of e
 * (See also problems 57 & 64.)
 * Find the sum of digits in the numerator of the 100th convergent.
 * The answer is 272.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problems60to69
{
    class Problem65
    {
        // from problem 57
        struct Fraction
        {
            public BigInteger n { get; private set; }
            public BigInteger d { get; private set; }

            public Fraction(BigInteger n, BigInteger d)
                : this()
            {
                this.n = n;
                this.d = d;
            }

            public override string ToString()
            {
                return string.Format("{0}/{1}", n, d);
            }

            public void add_x(BigInteger x)
            {
                n += (d * x);
            }

            public void invert()
            {
                BigInteger hld = n;
                n = d;
                d = hld;
            }
        }

        List<int> a;

        public long soln1()
        {
            long rv = 0;
            var sw = Stopwatch.StartNew();

            a = this.contFracFor_E(100).ToList();
            //for (int i=0; i <= 10; i++)
            //    Console.WriteLine("a[{0}] = {1} ", i, a[i]);

            //for (int i = 1; i < 10; i++)
            //    Console.WriteLine("seq[{0}] = {1}", i, getPartialValue(i));
            Fraction p100 = getPartialValue(100);
            //Console.WriteLine("seq[100] = {0}", p100);
            rv = sumOfDigits(p100.n);

            //Console.WriteLine();
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

        private Fraction getPartialValue(int n)
        {
            // n should not be < 1
            if (n == 1)
                return new Fraction(2, 1);
            int nCurr = n - 1;
            Fraction pVal = new Fraction(1, a[nCurr]);
            nCurr--;
            pVal.add_x(a[nCurr]);
            while (nCurr > 0)
            {
                pVal.invert();
                nCurr--;
                pVal.add_x(a[nCurr]);
            }
            return pVal;
        }

        private long sumOfDigits(BigInteger n)
        {
            long sum = 0;
            foreach (char ch in n.ToString())
            {
                sum += (int)ch - (int)'0';
            }
            return sum;
        }
    }
}
