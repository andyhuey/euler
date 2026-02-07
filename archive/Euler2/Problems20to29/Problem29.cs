/*
 * http://projecteuler.net/problem=29
 * Distinct powers
 * The answer is 9183.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems20to29
{
    class Problem29
    {
        public int soln1()
        {
            HashSet<double> powers = new HashSet<double>();
            for (int a = 2; a <= 100; a++)
                for (int b = 2; b <= 100; b++)
                {
                    powers.Add(Math.Pow(a, b));
                }
            return powers.Count();
        }
    }
}
