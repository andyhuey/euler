/*
 * http://projecteuler.net/problem=38
 * Pandigital multiples
 * Answer: n=9327, m=2, concat prod=932718654
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems30to39
{
    class Problem38
    {
        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            int n = 2;
            string concatProd;

            do
            {
                concatProd = n.ToString();
                int m = 2;
                while (concatProd.Length < 9 && !anyRepeatedDigits(concatProd) && !anyZeroes(concatProd))
                {
                    concatProd += (n * m).ToString();
                    m++;
                }
                if (concatProd.Length == 9 && !anyRepeatedDigits(concatProd) && !anyZeroes(concatProd))
                    Console.WriteLine("n={0}, m={1}, concat prod={2}", n, m-1, concatProd);
                n++;
            } while (n < 9999);

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return Int64.Parse(concatProd);
        }

        private bool anyRepeatedDigits(string concatProd)
        {
            // based on http://stackoverflow.com/a/245388/301677
            return concatProd.ToCharArray().GroupBy(x => x).Where(y => y.Count() > 1).Any();
        }

        private bool anyZeroes(string concatProd)
        {
            return concatProd.ToCharArray().Any(x => x == '0');
        }
    }
}
