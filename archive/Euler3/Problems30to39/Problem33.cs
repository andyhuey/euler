/*
 * http://projecteuler.net/problem=33
 * Digit canceling fractions
 * The answer is 100.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems30to39
{
    class Problem33
    {
        struct Fraction
        {
            public int n { get; private set; }
            public int d { get; private set; }

            public Fraction(int n, int d) : this()
            {
                this.n = n;
                this.d = d;
            }

            public override string ToString()
            {
                return string.Format("{0}/{1}", n, d);
            }

            public void reduce()
            {
                int myGcd = gcd(n, d);
                n /= myGcd;
                d /= myGcd;
            }

            private int gcd(int a, int b)
            {
                // http://en.wikipedia.org/wiki/Greatest_common_divisor
                // Using Euclid's algorithm
                // assuming a & b are > 0.
                //Console.WriteLine("a={0}, b={1}", a, b);
                if (a == b)
                    return a;
                else if (a > b)
                    return gcd(a - b, b);
                else
                    return gcd(a, b - a);
            }
        }

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            List<Fraction> results = new List<Fraction>();
            Fraction f;
            int n1, n2, d1, d2;

            for (int n = 11; n <= 99; n++)
            {
                if (n % 10 == 0)
                    continue;
                //Console.WriteLine(n);
                for (int d = n + 1; d <= 99; d++)
                {
                    if (d % 10 == 0)
                        continue;
                    
                    n1 = n / 10;
                    n2 = n % 10;
                    d1 = d / 10;
                    d2 = d % 10;

                    // do they have a shared digit?
                    if (n1 != d2 && n2 != d1)
                        continue;

                    // can we 'cancel the digits'?
                    float f1 = (float)n / d;
                    float f2 = (float)n1 / d2;
                    float f3 = (float)n2 / d1;
                    if (f1 == f2 || f1 == f3)
                    {
                        // we've got it, I think.
                        f = new Fraction(n, d);
                        Console.WriteLine(f);
                        results.Add(f);
                    }
                }
            }

            // multiply the results together...
            n1 = 1;
            d1 = 1;
            foreach (var frac in results)
            {
                n1 *= frac.n;
                d1 *= frac.d;
            }
            // and reduce the fraction
            f = new Fraction(n1, d1);
            f.reduce();
            Console.WriteLine("The resulting fraction is {0}.", f);

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return f.d;
        }

    }
}
