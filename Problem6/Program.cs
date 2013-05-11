/*
 * http://projecteuler.net/problem=6
 * Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("the answer is {0:n0}", soln1());
            Console.WriteLine("the answer from the PDF is {0:n0}", soln_pdf());

            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        static long soln_pdf()
        {
            long n = 100;
            long sum = (n * (n + 1)) / 2;
            long squareOfSums = sum * sum;
            long sumOfSquares = (n * (2 * n + 1) * (n + 1)) / 6;
            
            Console.WriteLine("sum of squares = {0:n0}", sumOfSquares);
            Console.WriteLine("square of sums = {0:n0}", squareOfSums);
            return squareOfSums - sumOfSquares;
        }

        static long soln1()
        {
            //int loopIterations = 0;
            long n = 100;
            var sw = Stopwatch.StartNew();

            // sum of the squares
            long sumOfSquares = 0;
            for (int i = 1; i <= n; i++)
            {
                sumOfSquares += (i * i);
            }
            Console.WriteLine("sum of squares = {0:n0}", sumOfSquares);

            // square of the sums
            long sum = 0, squareOfSums = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            squareOfSums = sum * sum;
            Console.WriteLine("square of sums = {0:n0}", squareOfSums);

            sw.Stop();
            //Console.WriteLine("Loop iterations: {0:n0}", loopIterations);
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return squareOfSums - sumOfSquares;
        }

    }
}
