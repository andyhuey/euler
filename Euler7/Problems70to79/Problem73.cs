/*
 * Problem 73
 * https://projecteuler.net/problem=73
 * Counting fractions in a range
 * For MAX_D = 8 -> 3; 80 -> 328
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems70to79
{
    class Problem73
    {
        public int MaxD { get; private set; }

        public static void run()
        {
            var myProblem = new Problem73(8);
            var ans = myProblem.soln1();
            Console.WriteLine("The answer for MAX D {0} is {1:n0} or {1}",
                myProblem.MaxD, ans);
        }

        public Problem73(int maxD)
        {
            MaxD = maxD;
        }

        public long soln1()
        {
            // initial brute force.
            long nCount = 0;
            float oneHalf = (float)1 / 2;
            float oneThird = (float)1 / 3;

            for (int d = 2; d <= MaxD; d++)
            {
                for (int n = 1; n < d; n++)
                {
                    if (Utils.gcd(n, d) == 1)
                    {
                        float thisFraction = (float)n / d;
                        if ((oneThird < thisFraction) && (thisFraction < oneHalf))
                        {
                            Console.WriteLine("{0}/{1}", n, d);
                            nCount++;
                        }
                    }
                }
            }

            return nCount;
        }
    }
}
