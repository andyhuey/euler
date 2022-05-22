using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems70to79
{
    public class Utils
    {

        public static int gcd(int a, int b)
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

        private static void swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        // prime method copied from problem 60.
        public static bool[] getPrimes(int nPrimeMax)
        {
            // get primes
            bool[] primes = new bool[nPrimeMax];
            int p = 2;
            int sqrt_max = (int)Math.Floor(Math.Sqrt(nPrimeMax));

            // initialize all to true
            for (int i = 2; i < nPrimeMax; i++)
                primes[i] = true;

            while (p <= sqrt_max)
            {
                // cross out all the multiple of p.
                for (int i = p * p; i < nPrimeMax; i += p)
                {
                    primes[i] = false;
                }

                // get the next p.
                do
                {
                    p++;
                } while (!primes[p]);
            }
            return primes;
        }

    }
}
