/*
 * http://projecteuler.net/problem=15
 * Lattice paths
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Numerics;

namespace Problems11to19
{
	public class Problem15
	{
		const int edge_length = 20;

		public long soln1()
		{
			// per http://www.robertdickau.com/lattices.html
            BigInteger n = factorial(2 * edge_length);
            BigInteger d = factorial(edge_length);
			d = d * d;
			return (long)(n / d);

		}

		// quick & dirty
        private BigInteger factorial(BigInteger n)
		{
			if (n <= 1)
				return 1;
			else
				return n * factorial(n-1);
		}

        long[,] route_vals;

        public long soln2()
        {
            // 14x14: 30 sec - prior to memoization.
            // very fast once you start caching results...
            var sw = Stopwatch.StartNew();

            route_vals = new long[edge_length + 1, edge_length + 1];
            Array.Clear(route_vals, 0, (edge_length+1) * (edge_length+1));

            long rv = find_routes(edge_length, edge_length);
            
            sw.Stop();
            Console.WriteLine("elapsed: {0} sec", sw.Elapsed.TotalSeconds);
            return rv;
        }

        long find_routes(long x, long y)
        {
            //Console.WriteLine("find_routes({0},{1})", x, y);
            if (route_vals[x, y] > 0)
                return route_vals[x, y];

            long routes = 0;
            if (y > 0)
                routes += find_routes(x, y - 1);
            
            if (x > 0)
                routes += find_routes(x - 1, y);

            if (x == 0 && y == 0)
                routes += 1;

            route_vals[x, y] = routes;
            return routes;
        }
	}
}

