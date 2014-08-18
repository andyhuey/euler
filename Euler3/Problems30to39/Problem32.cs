/*
 * http://projecteuler.net/problem=32
 * Pandigital products
 * The answer is 45,228 or 45228
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems30to39
{
    public class Problem32
    {
        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            HashSet<int> pandigProds = new HashSet<int>();
            int prod;
            int sumOfProds;

            //int x = 39; int y = 7254;  // 39 × 186 = 7254
            //Console.WriteLine("{0} * {1} -> {2}", x, y, this.isPandigitalProduct(x, y, out prod));
            //return 0;

            for (int i = 1; i <= 999; i++)
                for (int j = i; j <= 9999; j++)
                {
                    if (this.isPandigitalProduct(i, j, out prod))
                    {
                        pandigProds.Add(prod);
                        Console.WriteLine("{0} * {1} = {2}", i, j, prod);
                    }
                }

            sumOfProds = pandigProds.Sum();
            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return sumOfProds;
        }

        private bool isPandigitalProduct(int n1, int n2, out int prod)
        {
            // not the most efficient way...
            bool[] hasOnlyOne = new bool[10];
            hasOnlyOne[0] = true;   // no zeroes allowed.
            prod = n1 * n2;
            string s = string.Format("{0}{1}{2}", n1, n2, prod);
            int i;
            foreach (char ch in s)
            {
                i = (int)ch - (int)'0';
                if (hasOnlyOne[i])
                    return false;   // already got one...
                hasOnlyOne[i] = true;
            }

            return hasOnlyOne.All(x => x == true);
        }
    }
}
