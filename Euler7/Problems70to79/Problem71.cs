/*
 * http://projecteuler.net/problem=71
 * Ordered Fractions
 * 
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

        public int n { get; private set; }
        public int d { get; private set; }

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
            long val1 = this.n * f2.d;
            long val2 = f2.n * this.d;
            return val1.CompareTo(val2);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return (decimal)a.n * b.d == (decimal)b.n * a.d;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return (!(a == b));
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return (decimal)a.n * b.d > (decimal)b.n * a.d;
        }

        public static bool operator >=(Fraction a, Fraction b)
        {
            return (!(a < b));
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return (decimal)a.n * b.d < (decimal)b.n * a.d;
        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            return (!(a > b));
        }
    }

    class Problem71
    {
        const int MAX_D = 10000;
        Dictionary<Tuple<int, int>, int> gcd_cache = new Dictionary<Tuple<int, int>, int>();
        int cache_hits = 0;
        //List<Fraction> fracList = new List<Fraction>();
        
        Fraction targetFrac = new Fraction(3, 7);
        Fraction bestMatch = new Fraction(0, 1);

        public long soln1()
        {
            // brute force, for small set.
            for (int d = 2; d <= MAX_D; d++)
            {
                for (int n = 1; n < d; n++)
                {
                    var f = new Fraction(n, d);                    
                    // skip to next denominator if we overshoot target.
                    if (f > targetFrac)
                        break;
                    if (f > bestMatch && f < targetFrac && gcd(n, d) == 1)
                        bestMatch = f;
                }
            }

            // sort the list.
            //fracList.Sort();
            //foreach (var f in fracList)
            //{
            //    Console.Write(f);
            //    Console.Write(", ");
            //}
            Console.WriteLine("The best match is: {0}", bestMatch);

            return bestMatch.n;
        }

        private int gcd(int a, int b)
        {
            // copied from problem 33 (& old ver of p 69).
            // http://en.wikipedia.org/wiki/Greatest_common_divisor
            // Using Euclid's algorithm
            // assuming a & b are > 0.
            //Console.WriteLine("a={0}, b={1}", a, b);
            Tuple<int, int> tkey = new Tuple<int, int>(a, b);
            if (gcd_cache.ContainsKey(tkey))
            {
                cache_hits++;
                return gcd_cache[tkey];
            }

            int rv;
            if (a == b)
                rv = a;
            else if (a > b)
                rv = gcd(a - b, b);
            else
                rv = gcd(a, b - a);

            gcd_cache[tkey] = rv;
            return rv;
        }

    }
}
