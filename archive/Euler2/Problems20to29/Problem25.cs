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
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            // The answer is 4,782
            return n;
        }

        public long soln2()
        {
            // from the thread - grimbal - works.
            double n = Math.Ceiling((1000 - 1 + Math.Log10(Math.Sqrt(5))) / Math.Log10((1 + Math.Sqrt(5)) / 2));
            return Convert.ToInt64(n);
        }

        public long soln3()
        {
            // from the thread - google this: (999+log(sqrt(5)))/log(phi) +1
            double phi = (1 + Math.Sqrt(5)) / 2;
            double n = (999 + Math.Log10(Math.Sqrt(5))) / Math.Log10(phi) + 1;
            return Convert.ToInt64(Math.Floor(n));
        }

        public long soln4()
        {
            // from the thread - omgbentley - using LINQ - nifty, but slow.
            var sw = Stopwatch.StartNew();
            long ans = Fib().Select((x, i) => 
                new { Term = i + 1, Value = x }).First(t => t.Value.ToString().Length == 1000).Term;
            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return ans;
        }

        IEnumerable<BigInteger> Fib()
        {
            BigInteger current = 0, next = 1, temp;

            while (true)
            {
                yield return next;
                temp = current + next;
                current = next;
                next = temp;
            }
        }
    }
}
