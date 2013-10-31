/*
 * http://projecteuler.net/problem=23
   http://www.mathblog.dk/project-euler-23-find-positive-integers-not-sum-of-abundant-numbers/
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems20to29
{
    class Problem23
    {
        public long soln1()
        {
            // start by getting a list of 'abundant' numbers.
            const int MAX_N = 28124;
            string sdiv;
            List<int> abundant_numbers = new List<int>();
            for (int i = 1; i < MAX_N; i++)
            {
                if (is_abundant(i, sum_proper_divisors(i, out sdiv)))
                {
                    abundant_numbers.Add(i);
                    //Console.Write("{0} ", i);
                    //Console.WriteLine(sdiv);
                }
            }

            // and now...
            bool[] is_sum_of_abundant_nums = new bool[MAX_N];

            for (int i = 0; i < MAX_N; i++)
                is_sum_of_abundant_nums[i] = false;

            for (int i = 0; i < abundant_numbers.Count - 1; i++)
                for (int j = i; j < abundant_numbers.Count; j++)
                {
                    int x = abundant_numbers[i];
                    int y = abundant_numbers[j];
                    if (x + y < MAX_N)
                        is_sum_of_abundant_nums[x + y] = true;
                }

            long final_sum = 0;
            for (int i = 0; i < 28124; i++)
                if (!is_sum_of_abundant_nums[i])
                    final_sum += i;

            return final_sum;
            //Console.WriteLine("The answer is {0}", final_sum);
            //Console.ReadLine();
            // 4179871
        }

        static bool is_abundant(int n, int sum_div_n)
        {
            // "A number n is called deficient if the sum of its proper divisors is less than n 
            //  and it is called abundant if this sum exceeds n."
            return sum_div_n > n;
        }

        static int sum_proper_divisors(int n, out string div_list)
        {
            int i;
            List<int> divisors = new List<int>() { 1 };
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
            int sum_of_divisors = divisors.Sum();
            div_list = string.Format("for n={0}: sum={1} / {2}", n, sum_of_divisors, string.Join(", ", divisors));
            return sum_of_divisors;
        }
    }
}
