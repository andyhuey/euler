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
    }
}
