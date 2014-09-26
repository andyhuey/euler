/*
 * https://projecteuler.net/problem=57
 * Square root convergents
 * 
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problems50to59
{
    class Problem57
    {
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

            public void addTwo()
            {
                n += (d * 2);
            }

            public void addOne()
            {
                n += d;
            }

            public void invert()
            {
                BigInteger hld = n;
                n = d;
                d = hld;
            }
        }

        public long soln1()
        {
            long nCount = 0;
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                // start w/ 1/2.
                Fraction f = new Fraction(1, 2);

                for (int j = 0; j < i; j++)
                {
                    f.addTwo();
                    f.invert();
                }
                f.addOne();

                //Console.WriteLine("{0}: {1}", i, f);
                if (f.n.ToString().Length > f.d.ToString().Length)
                    nCount++;
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return nCount;
        }

    }
}
