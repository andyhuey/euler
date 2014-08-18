/*
 * http://projecteuler.net/problem=32
 * Pandigital products
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems30to39
{
    public class Problem32
    {
        public long soln1()
        {
            HashSet<int> pandigProds = new HashSet<int>();
            int prod;

            // 39 × 186 = 7254
            //int x = 39; int y = 186;
            //Console.WriteLine("{0} * {1} -> {2}", x, y, this.isPandigitalProduct(x, y, out prod));

            // a little test.
            pandigProds.Add(1);
            pandigProds.Add(2);
            pandigProds.Add(1);
            foreach (int i in pandigProds)
                Console.WriteLine(i);

            return pandigProds.Sum();

            for (int i = 1; i <= 999; i++)
                for (int j = i; j <= 999; j++)
                {
                    if (this.isPandigitalProduct(i, j, out prod))
                    {
                        pandigProds.Add(prod);
                        Console.WriteLine("{0} * {1} = {2}", i, j, prod);
                    }
                }

            return pandigProds.Sum();
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
                hasOnlyOne[i] = !hasOnlyOne[i] && true;
            }

            return hasOnlyOne.All(x => x == true);
        }
    }
}
