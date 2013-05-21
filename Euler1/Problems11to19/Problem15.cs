/*
 * http://projecteuler.net/problem=15
 * Lattice paths
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problems11to19
{
	public class Problem15
	{
		const int edge_length = 3;

		public long soln1()
		{
			// per http://www.robertdickau.com/lattices.html
			long n = factorial(2 * edge_length);
			long d = factorial(edge_length);
			d = d * d;
			return n / d;

		}

		// quick & dirty
		private long factorial(long n)
		{
			if (n <= 1)
				return 1;
			else
				return n * factorial(n-1);
		}
	}
}

