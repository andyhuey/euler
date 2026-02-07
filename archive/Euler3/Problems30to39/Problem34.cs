/*
 * http://projecteuler.net/problem=34
 * Digit factorials
 * Find the sum of all numbers which are equal to the sum of the factorial of their digits.
 * The answer is 40,730.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems30to39
{
    public class Problem34
    {
        public int[] myFactorials;

        private void calcFactorials()
        {
            // create an array of the factorials for 0..9.
            myFactorials = new int[10];
            myFactorials[0] = 1;
            for (int i = 1; i <= 9; i++)
            {
                myFactorials[i] = myFactorials[i - 1] * i;
            }
        }

        private int sumOfFactsOfDigits(int n)
        {
            // get the sum of the factorials for the digits in 'n'.
            int sum = 0;
            int digit;

            foreach (char ch in n.ToString())
            {
                digit = (int)ch - (int)'0';
                sum += myFactorials[digit];
            }

            return sum;
        }

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            long mySum = 0;

            this.calcFactorials();
            //for (int i = 0; i <= 9; i++)
            //    Console.WriteLine("{0}! = {1}", i, myFactorials[i]);

            //Console.WriteLine(this.sumOfFactsOfDigits(123));
            // brute force, just to see what kind of pattern develops:
            for (int i = 3; i < 1000000; i++)
            {
                if (i == this.sumOfFactsOfDigits(i))
                {
                    Console.WriteLine("{0} = {1}", i, this.sumOfFactsOfDigits(i));
                    mySum += i;
                }
                //if (i % 1000000 == 0)
                //    Console.WriteLine("At {0:n0}...", i);
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return mySum;
        }
    }
}
