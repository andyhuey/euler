/*
 * http://projecteuler.net/problem=25
   1000-digit Fibonacci number
   
   (problem 2 was the last one to involve Fibonacci numbers)
   http://www.mathsisfun.com/numbers/fibonacci-sequence.html
   http://mathworld.wolfram.com/FibonacciNumber.html
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace Problems20to29
{
    class Problem25
    {

        public long soln1()
        {
            // I wonder if brute force will work...
            var sw = Stopwatch.StartNew();

            BigInteger ThousandDigitNumber = BigInteger.Pow(10, 999);
            //Console.WriteLine(ThousandDigitNumber.ToString().Length); -- yep, it's 1000 digits.

            long n = 2;
            BigInteger[] last_three_fib = { 0, 1, 1 };

            while (last_three_fib[2] < ThousandDigitNumber)
            {
                n++;
                last_three_fib[0] = last_three_fib[1];
                last_three_fib[1] = last_three_fib[2];
                last_three_fib[2] = last_three_fib[0] + last_three_fib[1];
                //Console.WriteLine("f({0}) = {1}", n, last_three_fib[2]);
                if (n % 1000 == 0)
                    Console.WriteLine("n={0}...", n);
            }

            Console.WriteLine("f({0}) = {1}", n, last_three_fib[2]);
            sw.Stop();
            Console.WriteLine("elapsed: {0} sec", sw.Elapsed.Seconds);

            return n;
        }

    }
}
