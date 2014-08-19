/*
 * http://projecteuler.net/problem=38
 * Pandigital multiples
 * 
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
            } while (n < 999999999);

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
/*
n=9, m=5, concat prod=918273645
n=192, m=3, concat prod=192384576
n=219, m=3, concat prod=219438657
n=273, m=3, concat prod=273546819
n=327, m=3, concat prod=327654981
n=6729, m=2, concat prod=672913458
n=6792, m=2, concat prod=679213584
n=6927, m=2, concat prod=692713854
n=7269, m=2, concat prod=726914538
n=7293, m=2, concat prod=729314586
n=7329, m=2, concat prod=732914658
n=7692, m=2, concat prod=769215384
n=7923, m=2, concat prod=792315846
n=7932, m=2, concat prod=793215864
n=9267, m=2, concat prod=926718534
n=9273, m=2, concat prod=927318546
n=9327, m=2, concat prod=932718654
 */