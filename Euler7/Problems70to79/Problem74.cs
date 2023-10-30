/*
 * Problem 74
 * https://projecteuler.net/problem=74
 * Digit Factorial Chains
 * The answer is 402.
 */
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problems70to79
{
    internal class Problem74
    {
        private Dictionary<int, int> factorialDict = new Dictionary<int, int>();
        private Dictionary<int, int> loopLenDict = new Dictionary<int, int>();
        private int loopLenHits = 0;

        public static void Run()
        {
            //RunTest();
            var myProblem = new Problem74();
            int ans = myProblem.Soln1();
            Console.WriteLine("The answer is {0}.", ans);
            myProblem.ShowStats();
        }

        public static void RunTest()
        {
            // 145 -> 1
            // 169 -> 3
            // 69 -> 5
            int initN = 69;
            var myProblem = new Problem74();
            var ans = myProblem.FactorialSumLoop(initN);
            Console.WriteLine("The answer for initial N {0} is {1:n0}",
                initN, ans);
        }

        private int Soln1()
        {
            // "How many chains, with a starting number below one million, 
            // contain exactly sixty non-repeating terms?"
            int count = 0;
            for (int i =1; i < 1000000; i++)
            {
                int loopLen = FactorialSumLoop(i);
                loopLenDict[i] = loopLen;
                if (loopLen == 60)
                {
                    Console.WriteLine("Input {0} has 60 terms.", i);
                    count++;
                }
            }
            return count;
        }

        private int FactorialSumLoop(int initN)
        {
            // how long does the sequence take to loop?
            List<int> myValues = new List<int>();
            int n = initN;
            int count = 0;
            int sum;
            while (!myValues.Contains(n))
            {
                // can we short-circuit?
                if (loopLenDict.ContainsKey(n))
                {
                    loopLenHits++;
                    count += loopLenDict[n];
                    return count;
                }
                //Console.Write("{0} -> ", n);
                myValues.Add(n);
                sum = SumOfFactorialOfDigits(n);
                n = sum;
                count++;
            }
            //Console.WriteLine("({0})", n);
            return count;
        }

        private int SumOfFactorialOfDigits(int n)
        {
            // for example, 1! + 4! + 5! = 1 + 24 + 120 = 145
            // (original SumOfDigits from problem 65)
            int sum = 0;
            foreach (char ch in n.ToString())
            {
                int digit = (int)ch - (int)'0';
                sum += Factorial(digit);
            }
            return sum;
        }

        private int Factorial(int n)
        {
            if (factorialDict.ContainsKey(n))
                return factorialDict[n];

            // from problem 53
            int rv = 1;
            for (int i = 1; i <= n; i++)
                rv *= i;
            factorialDict.Add(n, rv);
            return rv;
        }

        private void ShowStats()
        {
            Console.WriteLine("factorialDict: {0} entries", factorialDict.Count);
            Console.WriteLine("loopLenDict: {0} entries", loopLenDict.Count);
            Console.WriteLine("loopLenHits: {0}", loopLenHits);
        }

    }
}
