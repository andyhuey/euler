/*
 * Problem 77
 * https://projecteuler.net/problem=77
 * Prime Summations
 * What is the first value which can be written as the sum of primes in over five thousand ways?
 * Written with help from Claude Code.
 */

namespace Problems70to79
{
    internal class Problem77
    {
        public static void Run()
        {
            Console.WriteLine("Started at {0}", DateTime.Now);
            var myProblem = new Problem77();
            //myProblem.HowManyWays(10);
            myProblem.RunTests();
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
            // given N, how many ways can it be written as a sum of primes?
            // if (N < 2) return 0;
            bool[] primes = Utils.GetPrimes(N + 1);
            // PrintPrimes(N, primes);

            int[] ways = new int[N + 1];
            ways[0] = 1;
            for (int i = 1; i <= N; i++)
                if (primes[i])
                    for (int j = i; j <= N; j++)
                        ways[j] += ways[j - i];
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
