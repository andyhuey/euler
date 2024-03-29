﻿/*
 * http://projecteuler.net/problem=71
 * Ordered Fractions
 * The best match is: 428570/999997
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems70to79
{
    struct Fraction : IComparable<Fraction>
    {
        // borrowing some code from http://www.codeproject.com/Articles/11971/Fractions-in-C

        public int n { get; set; }
        public int d { get; set; }

        public Fraction(int n, int d)
            : this()
        {
            this.n = n;
            this.d = d;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", n, d);
        }

        public void add_x(int x)
        {
            n += (d * x);
        }

        public void invert()
        {
            int hld = n;
            n = d;
            d = hld;
        }

        public int CompareTo(Fraction f2)
        {
            // common decominator method.
            long val1 = checked((long)this.n * f2.d);
            long val2 = checked((long)f2.n * this.d);
            return val1.CompareTo(val2);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.CompareTo(b) == 0;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return (!(a == b));
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator >=(Fraction a, Fraction b)
        {
            return (!(a < b));
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            return (!(a > b));
        }

        public override bool Equals(object? o)
        {
            // just adding this and GetHashCode() in to squelch warnings.
            // https://msdn.microsoft.com/en-us/library/7h9bszxx%28v=vs.100%29.aspx
            // https://msdn.microsoft.com/en-us/library/ms173147%28v=vs.80%29.aspx
            if (o == null)
                return false;
            Fraction f2 = (Fraction)o;
            return this == f2;
        }

        public override int GetHashCode()
        {
            return this.n ^ this.d;
        }
    }

    class Problem71
    {
        const int MAX_D = 1000000;
        
        Fraction targetFrac = new Fraction(3, 7);
        Fraction bestMatch = new Fraction(0, 1);

        public long soln1()
        {
            for (int d = MAX_D; d >= 2; d--)
            {
                double cn = (double)(targetFrac.n * d) / targetFrac.d;
                int cni = (int)Math.Floor(cn);
                var f = new Fraction(cni, d);
                if (f == targetFrac)
                    continue;
                if (f > bestMatch && gcd(f.n, f.d) == 1)
                {
                    bestMatch = f;
                    Console.WriteLine("Best match so far is {0}.", f);
                }
            }


            Console.WriteLine("The best match is: {0}", bestMatch);

            return bestMatch.n;
        }

        private void swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        private int gcd(int a, int b)
        {
            // http://en.wikipedia.org/wiki/Greatest_common_divisor
            // assuming a & b are > 0.
            //Console.Write("a={0}, b={1} ", a, b);
            int r;
            if (a > b)
                swap(ref a, ref b);

            while (b != 0)
            {
                r = a % b;
                a = b;
                b = r;
            }
            //Console.WriteLine(" --> {0}", a);
            return a;
        }

    }
}
