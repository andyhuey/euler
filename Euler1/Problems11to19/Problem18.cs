/*
 * http://projecteuler.net/problem=8
 * Maximum path sum I
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Numerics;

namespace Problems11to19
{
    class Problem18
    {
        List<List<int>> triangle;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            triangle = new List<List<int>>() {
                new List<int>() {3},
                new List<int>() {7, 4},
                new List<int>() {2,4,6},
                new List<int>() {8,5,9,3}
            };

            for (int x = triangle.Count - 1; x > 0; x--)
            {
                for (int y = 0; y < x; y++)
                {
                    triangle[x - 1][y] += Math.Max(triangle[x][y], triangle[x][y+1]);
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);

            return triangle[0][0];
        }
    }
}
