/*
 * http://projecteuler.net/problem=4
 * A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
 * Find the largest palindrome made from the product of two 3-digit numbers.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projects1to10
{
    class Problem4
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("the answer is {0}", soln_pdf());    // 913 * 993 = 906609

        //    Console.WriteLine("Press enter...");
        //    Console.ReadLine();
        //}

        static int soln1()
        {
            // mine
            int loopIterations = 0;
            int low = 0;
            int ans = 0;
            for (int i = 999; i >= 100; i--)
            {
                Console.WriteLine("i={0}, j min={1}", i, Math.Max(100, low));
                for (int j = 999; j >= Math.Max(100, low); j--)
                {
                    loopIterations++;
                    int a = i * j;
                    if (isPalindrome(a))
                    {
                        if (a > ans)
                        {
                            Console.WriteLine("{0} * {1} = {2}", i, j, a);
                            low = Math.Max(low, Math.Min(i, j));
                            ans = a;
                        }
                    }
                }
            }
            // first shot: loop iterations: 810,000
            // a little better: loop iterations: 405,450
            // a good bit better: loop iterations: 82,212
            Console.WriteLine("loop iterations: {0}", loopIterations);
            return ans;
        }

        static int soln2_ng()
        {
            int loopIterations = 0;
            int low = 0;
            int ans = 0;
            for (int i = 999; i >= 100; i--)
            {
                //Console.WriteLine("i={0}, j min={1}", i, Math.Max(100, low));
                //Console.ReadLine();
                for (int j = 999; j >= i; j--)
                {
                    loopIterations++;
                    int a = i * j;
                    if (isPalindrome(a))
                    {
                        //Console.WriteLine("{0} * {1} = {2}", i, j, a);
                        if (a < ans)
                            break;  // since i*j is always going to be too small
                        if (a > ans)
                        {
                            Console.WriteLine("{0} * {1} = {2}", i, j, a);
                            low = Math.Max(low, Math.Min(i, j));
                            ans = a;
                        }
                    }
                }
            }
            // ...and back to not so good: loop iterations: 293,145
            Console.WriteLine("loop iterations: {0}", loopIterations);
            return ans;
        }

        static int soln_pdf()
        {
            // solution from the PDF
            int loopIterations = 0;
            int largestPalindrome = 0;
            int a = 999;
            int b, db;

            while (a >= 100)
            {
                if (a % 11 == 0)
                {
                    b = 999;
                    db = 1;
                }
                else
                {
                    b = 990;    //The largest number less than or equal 999
                                //and divisible by 11
                    db = 11;
                }
                while (b >= a)
                {
                    loopIterations++;
                    if (a*b <= largestPalindrome)
                        break;
                    if (isPalindrome(a*b))
                    {
                        largestPalindrome = a*b;
                    }
                    b = b-db;
                }
                a--;
            }
            // loop iterations: 1330 -- much better than mine!
            Console.WriteLine("loop iterations: {0}", loopIterations);
            return largestPalindrome;
    }

        static bool isPalindrome(int n)
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
