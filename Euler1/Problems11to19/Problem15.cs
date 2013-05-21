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
	}
}

