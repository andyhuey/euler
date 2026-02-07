/*
 * Problem 77
 * https://projecteuler.net/problem=77
 * Prime Summations
 * What is the first value which can be written as the sum of primes in over five thousand ways?
 * Written with help from Claude Code.
 * The answer is 71, which can be written in 5007 ways.
 * (Note that this could also be done similar to Problem 31, but with primes instead of coins.)
 */

namespace Problems70to79
{
    internal class Problem77
    {
        private bool[] primes;
        private int[] ways;

        public Problem77(int maxN)
        {
            primes = Utils.GetPrimes(maxN + 1);
            ways = GetWays(maxN);
        }

        private int[] GetWays(int maxN)
        {
            int[] ways = new int[maxN + 1];
            ways[0] = 1;
            for (int i = 1; i <= maxN; i++)
                if (primes[i])
                    for (int j = i; j <= maxN; j++)
                        ways[j] += ways[j - i];
            return ways;
        }

        public static void Run()
        {
            Console.WriteLine("Started at {0}", DateTime.Now);
            int maxN = 100; // just a guess.
            var myProblem = new Problem77(maxN);
            int targetValue = 5000; // "more than 5000 ways."
            for (int n = 1; n <= maxN; n++)
            {
                int numWays = myProblem.HowManyWays(n);
                if (numWays > targetValue)
                {
                    Console.WriteLine("The answer is {0}, which can be written in {1} ways.", 
                        n, numWays);
                    break;
                }
            }
            //Console.WriteLine("PS(99) = {0}", myProblem.HowManyWays(99));
            //myProblem.RunTests();
        }

        private void RunTests()
        {
            // expected PS(N) for N=1..10
            int[] expected = [0, 1, 1, 1, 2, 2, 3, 3, 4, 5];
            bool allPass = true;
            for (int n = 1; n <= 10; n++)
            {
                int result = HowManyWays(n);
                bool pass = result == expected[n - 1];
                Console.WriteLine("PS({0}) = {1}{2}  {3}", 
                    n, result, 
                    pass ? "" : $" (expected {expected[n - 1]})", 
                    pass ? "PASS" : "FAIL");
                if (!pass) allPass = false;
            }
            Console.WriteLine(allPass ? "All tests passed." : "Some tests FAILED.");
        }

        private int HowManyWays(int N)
        {
            return ways[N];
        }

        private static void PrintPrimes(int N, bool[] primes)
        {
            // print primes for debugging.
            Console.WriteLine($"Primes up to {N}:");
            for (int i = 2; i < N; i++)
                if (primes[i])
                    Console.Write($"{i} ");
        }
    }        
}
