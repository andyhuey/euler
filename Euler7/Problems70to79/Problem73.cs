/*
 * Problem 73
 * https://projecteuler.net/problem=73
 * Counting fractions in a range
 * For MAX_D = 8 -> 3; 80 -> 328
 * The answer for MAX D 12000 is 7,295,372 or 7295372.
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
            var myProblem = new Problem73(12000);
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
            // a little smarter...
            long nCount = 0;

            for (int d = 2; d <= MaxD; d++)
            {
                if (d % 1000 == 0)
                    Console.WriteLine("Processing d={0}...", d);
                for (int n = d / 3 + 1; n <= (d - 1) / 2; n++)
                {
                    if (Utils.gcd(n, d) == 1)
                    {
                        //Console.WriteLine("{0}/{1}", n, d);
                        nCount++;
                    }
                }
            }
            return nCount;
        }

        public long soln2()
        {
            // from the PDF...
            // "Farey Sequences"
            // I don't understand this...
            int limit = 10000;
            int a = 1;
            int b = 3;
            int c = 3333;
            int d = 9998;
            int count = 0;

            while (!(c == 1 && d == 2))
            {
                count++;
                int k = (limit + b) / d;
                int e = k * c - a;
                int f = k * d - b;
                a = c;
                b = d;
                c = e;
                d = f;
            }
            return count;

        }
    }
}
