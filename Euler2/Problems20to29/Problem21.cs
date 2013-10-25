/*
 * http://projecteuler.net/problem=21
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems20to29
{
    class Problem21
    {
        public long soln1()
        {
            const int NMAX = 10000;
            Dictionary<int, int> divisor_sums = new Dictionary<int, int>();

            for (int i = 1; i < NMAX; i++)
            {
                divisor_sums[i] = sum_proper_divisors(i);
                //Console.WriteLine("n={0}, d(n)={1}", i, divisor_sums[i]);
            }

            //Console.WriteLine("n={0}, d(n)={1}", 220, sum_proper_divisors(220));
            //Console.WriteLine("n={0}, d(n)={1}", 284, sum_proper_divisors(284));

            // figure out which are 'amicable' numbers...
            List<int> amicable_numbers = new List<int>();
            int j;
            for (int i = 1; i < NMAX; i++)
            {
                j = divisor_sums[i];
                if (j <= NMAX && j != i && divisor_sums[j] == i)
                {
                    if (!amicable_numbers.Contains(i))
                        amicable_numbers.Add(i);
                    if (!amicable_numbers.Contains(j))
                        amicable_numbers.Add(j);
                }
            }

            int sum_of_amicable_numbers = amicable_numbers.Sum();
            return sum_of_amicable_numbers;
            //Console.WriteLine("The answer is {0}", sum_of_amicable_numbers);
            //Console.ReadLine();
        }

        static int sum_proper_divisors(int n)
        {
            int i;
            List<int> divisors = new List<int>() {1};
            for (i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    divisors.Add(i);
                    divisors.Add(n / i);
                }
            }
            // if n is a square...
            if (i * i == n)
                divisors.Add(i);
            // just output the list for now...
            int sum_of_divisors = divisors.Sum();
            //Console.WriteLine("for n={0}: sum={1} / {2}", n, sum_of_divisors, string.Join(", ", divisors));
            return sum_of_divisors;
        }
    }
}
