/*
 * https://projecteuler.net/problem=66
 * Diophantine equation: x^2 – Dy^2 = 1
 * Find the value of D <= 1000 in minimal solutions of x for which the largest value of x is obtained.
 * The answer is 661.
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

        public Fraction(int n, decimal d)
            : this()
        {
            this.n = n;
            this.d = new BigInteger(d);
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", n, d);
        }

        public void add_x(BigInteger x)
        {
            n += (d * x);
        }

        public void add_x(decimal x)
        {
            n += (d * new BigInteger(x));
        }

        public void invert()
        {
            BigInteger hld = n;
            n = d;
            d = hld;
        }

    }

    class Problem66
    {
        public long soln1()
        {
            int D;
            BigInteger largest_min_x = 1;
            long D_for_largest_min_x = 0;

            var sw = Stopwatch.StartNew();

            for (D = 2; D <= 1000; D++)
            {
                if (isPerfectSquare(D))
                    continue;

                List<decimal> seq = fractionExpand(D);

                //StringBuilder sb = new StringBuilder();
                //sb.AppendFormat("Fraction expand for {0} is: ", D);
                //foreach (var d in seq)
                //    sb.AppendFormat("{0} ", d);
                //Console.WriteLine(sb);

                bool solnFound = false;
                int n = 1;
                BigInteger x = 0;
                BigInteger y = 0;
                while (!solnFound)
                {
                    Fraction f = getPartialValue(n, seq);
                    //Console.WriteLine("For n={0}, fraction is {1}.", n, f);
                    // x^2 – Dy^2 = 1
                    x = f.n;
                    y = f.d;
                    if ((x * x) - (D * y * y) == 1)
                        solnFound = true;
                    else
                        n++;
                }
                if (x > largest_min_x)
                {
                    largest_min_x = x;
                    D_for_largest_min_x = D;
                    Console.WriteLine("For D={0}, min x={1:n0}, y={2:n0}.", D, x, y);
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return D_for_largest_min_x;
        }

        private decimal getSeqValue(List<decimal> a, int n)
        {
            // repeat the continued fraction sequence
            // https://en.wikipedia.org/wiki/Continued_fraction
            if (n == 0)
                return a[0];
            else
                return a[(n - 1) % (a.Count - 1) + 1];
        }

        private Fraction getPartialValue(int n, List<decimal> a)
        {
            // n should not be < 1
            if (n == 1)
                return new Fraction(2, 1);
            int nCurr = n - 1;
            Fraction pVal = new Fraction(1, getSeqValue(a,nCurr));
            nCurr--;
            pVal.add_x(getSeqValue(a, nCurr));
            while (nCurr > 0)
            {
                pVal.invert();
                nCurr--;
                pVal.add_x(getSeqValue(a,nCurr));
            }
            return pVal;
        }
        
        private List<decimal> fractionExpand(int S)
        {
            // http://en.wikipedia.org/wiki/Methods_of_computing_square_roots#Continued_fraction_expansion
            // S is the number we want a square root of.
            int n = 0;
            List<decimal> m, d, a;
            m = new List<decimal>();
            d = new List<decimal>();
            a = new List<decimal>();
            m.Add(0);
            d.Add(1);
            a.Add(Math.Floor((decimal)Math.Sqrt(S)));
            while (a[n] != a[0] * 2)
            {
                //Console.WriteLine("m={0}, d={1}, a={2}", m[n], d[n], a[n]);
                m.Add(d[n] * a[n] - m[n]);
                d.Add((S - m[n + 1] * m[n + 1]) / d[n]);
                if (d[n + 1] == 0)
                    return a;   // perfect square.
                a.Add(Math.Floor((a[0] + m[n + 1]) / d[n + 1]));
                n++;
            }
            //Console.WriteLine("m={0}, d={1}, a={2}", m[n], d[n], a[n]);
            return a;
        }

        //private bool isPerfectSquare(long x)
        //{
        //    // http://stackoverflow.com/a/4885965/301677 - won't work for really big numbers.
        //    double sqrt = Math.Sqrt(x);
        //    return sqrt % 1 == 0;
        //}

        private bool isPerfectSquare(double x)
        {
            // is it already an int?
            if (x % 1 != 0)
                return false;
            // yes.
            double sqrt = Math.Sqrt(x);
            return sqrt % 1 == 0;
        }

        public long soln2()
        {
            // from Euler forums - Thu, 12 Feb 2015, 08:49 - sergii
            // "Algorithm is described here: http://mathworld.wolfram.com/PellEquation.html"
            const int D_MAX = 1000;
            var sw = new Stopwatch();
            sw.Start();

            BigInteger x = 0;
            var maxD = 0;
            for (var d = 2; d <= D_MAX; d++)
            {
                var a = GetSquareRootFractionExpansion(d);
                if (a.Count == 0)
                {
                    continue;
                }

                var r = a.Count - 2;
                var n = r % 2 == 1 ? r : 2 * r + 1;

                BigInteger p0 = a[0];
                BigInteger p1 = a[0] * a[1] + 1;
                for (var i = 2; i <= n; i++)
                {
                    var tmp = p1;
                    p1 = a[((i - 1) % (r + 1)) + 1] * p1 + p0;
                    p0 = tmp;
                }

                if (p1 > x)
                {
                    x = p1;
                    maxD = d;
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return maxD;
        }
        
        private static IList<int> GetSquareRootFractionExpansion(int n)
        {
            var r = Math.Sqrt(n);
            var m = 0;
            var d = 1;
            var a = (int)r;

            if ((a * a) == n)
            {
                return new int[0];
            }

            var list = new List<int> { a };

            while (a != 2 * list[0])
            {
                m = d * a - m;
                d = (n - m * m) / d;
                a = (int)(r + m) / d;
                list.Add(a);
            }

            return list;
        }
    }
}
