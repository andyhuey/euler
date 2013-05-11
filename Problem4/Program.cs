/*
 * http://projecteuler.net/problem=4
 * A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
 * Find the largest palindrome made from the product of two 3-digit numbers.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("the answer is {0}", soln1());    // 913 * 993 = 906609

            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        static int soln1()
        {
            // brute force
            int loopIterations = 0;
            int ans = 0;
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100; j < 1000; j++)
                {
                    loopIterations++;
                    int a = i * j;
                    if (isPanindrome(a))
                    {
                        //Console.WriteLine("{0} * {1} = {2}", i, j, a);
                        if (a > ans)
                        {
                            Console.WriteLine("{0} * {1} = {2}", i, j, a);
                            ans = a;
                        }
                    }
                }
            }
            // first shot: loop iterations: 810,000
            Console.WriteLine("loop iterations: {0}", loopIterations);
            return ans;
        }

        static bool isPanindrome(int n)
        {
            string s = n.ToString();
            return s.Equals(s.ReverseString());
        }
        
    }
    
    public static class MyExtensions
    {
        /// <summary>
        /// Receives string and returns the string with its letters reversed.
        /// http://www.dotnetperls.com/reverse-string
        /// see also: http://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
        /// </summary>
        public static string ReverseString(this string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
