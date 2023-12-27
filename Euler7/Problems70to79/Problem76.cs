/*
 * Problem 76
 * https://projecteuler.net/problem=76
 * Counting Summations
 * How many different ways can N be written as a sum of at least two positive integers?
 */
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems70to79
{
    internal class Problem76
    {
        public static void Run()
        {
            Console.WriteLine("Started at {0}", DateTime.Now);
            var myProblem = new Problem76();
            //int N = 2;      // just 1+1
            //int N = 3;      // 2+1, 1+1+1
            //int N = 4;
            //int N = 5;   // 6 ways
            //int N = 10;
            int N = 100;    // 190569291
            int ans = myProblem.Soln2(N);
            Console.WriteLine("The answer is {0}.", ans);
        }

        private int Soln1(int N)
        {
            // ** doesn't work. **
            var allSums = GetSumLists(N);
            foreach(var s in allSums)
            {
                Console.WriteLine(s);
                if (s.GetSum() != N)
                    throw new Exception("Unexpected sum.");
                if (!s.CheckSorted())
                    throw new Exception("List is not sorted.");
                if (allSums.Count(x => x.Equals(s)) > 1)
                    throw new Exception("Duplicate entry in list.");
            }
            return allSums.Count();
        }

        private List<SumList> GetSumLists(int N) 
        {
            Console.WriteLine($"In GetSumLists({N}).");
            List<SumList> allSums = new List<SumList>();
            for (int i = N - 1; i >= ((float)N / 2); i--)
            {
                allSums.Add(new SumList(new List<int> { i, N - i }));
            }
            if (N > 2)
            {
                foreach (var sl in GetSumLists(N - 1))
                {
                    sl.AddToList(1);
                    allSums.Add(sl);
                }
            }
            return allSums;
        }

        private int Soln2(int N)
        {
            // from problem 31.
            int[] S = Enumerable.Range(1, N).ToArray();
            int m = S.Length;
            int n = N;
            return Counter(S, m, n) - 1;
        }

        private int Counter(int[] S, int m, int n)
        {
            // If n is 0 then there is 1 solution (do not include any coin)
            if (n == 0)
                return 1;

            // If n is less than 0 then no solution exists
            if (n < 0)
                return 0;

            // If there are no coins and n is greater than 0, then no solution exists
            if (m <= 0 && n >= 1)
                return 0;

            // count is sum of solutions (i) including S[m-1] (ii) excluding S[m-1]
            return Counter(S, m - 1, n) + Counter(S, m, n - S[m - 1]);
        }
        private int Soln3(int N)
        {
            // from https://web.archive.org/web/20120316021735/https://www.mathblog.dk/project-euler-76-one-hundred-sum-integers/
            int target = N;
            int[] ways = new int[target + 1];
            ways[0] = 1;

            for (int i = 1; i <= N - 1; i++)
            {
                for (int j = i; j <= target; j++)
                {
                    ways[j] += ways[j - i];
                }
            }
            return ways[ways.Length - 1];
        }
    }

    internal class SumList
    {
        List<int> intList;

        public SumList()
        {
            intList = new List<int>();
        }

        public SumList(IEnumerable<int> list)
        {
            intList = new List<int>(list);
        }

        public void AddToList(int n)
        {
            intList.Add(n);
        }

        public int GetSum()
        {
            return intList.Sum();
        }

        public bool CheckSorted()
        {
            for (int i = 1; i < intList.Count; i++)
            {
                if (intList[i] > intList[i - 1])
                    return false;
            }
            return true;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is SumList)
            {
                SumList sl = (SumList)obj;
                return this.intList.SequenceEqual(sl.intList);
            }
            return false;
        }

        public override string ToString()
        {
            return string.Join(" + ", intList) + " = " + GetSum().ToString();
        }

        public override int GetHashCode()
        {
            return intList.GetHashCode();
        }
    }
}
