/*
 * Problem 75
 * https://projecteuler.net/problem=75
 * Singular Integer Right Triangles
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems70to79
{
    internal class Problem75
    {
        public static void Run()
        {
            var myProblem = new Problem75();
            int ans = myProblem.Soln1(120);
            //int ans = myProblem.Soln1(1500000);
            Console.WriteLine("The answer is {0}.", ans);
        }

        private int Soln1(int lMax)
        {
            int nTotal = 0;
            for (int i = 1; i <= lMax; i++)
                if (FindIntRtTriangles(i) == 1)
                    nTotal++;
            return nTotal;
        }
        
        private int FindIntRtTriangles(int L)
        {
            List<Tuple<int, int, int>> trianges = new List<Tuple<int, int, int>>();
            int nFound = 0;

            for (int x = 1; x < L; x++)
                for (int y = x+1; y < L-x; y++)
                {
                    int z = L - x - y;
                    //Console.WriteLine("trying: ({0}, {1}, {2})", x, y, z);
                    if (x*x + y*y == z*z)
                    {
                        // got it.
                        trianges.Add(Tuple.Create(x, y, z));
;                       //Console.WriteLine("{0}cm: ({1}, {2}, {3})", L, x, y, z);
                        nFound++;
                    }
                }
            if (nFound > 0)
            {
                Console.Write("{0}cm: ", L);
                foreach (var t in trianges)
                    Console.Write("({0}, {1}, {2}) ", t.Item1, t.Item2, t.Item3);
                Console.WriteLine();
            }
            return nFound;
        }
    }
}
