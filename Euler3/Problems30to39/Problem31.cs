using System;

namespace Problems30to39
{
	public class Problem31
	{
		public long soln1()
		{
			int[] S = { 1, 2, 5 };
			int m = S.Length;
			int n = 5;
			return count (S, m, n);
		}

		private long count(int[] S, int m, int n)
		{
			// from http://www.geeksforgeeks.org/dynamic-programming-set-7-coin-change/
			// If n is 0 then there is 1 solution (do not include any coin)
			if (n == 0)
				return 1;

			// If n is less than 0 then no solution exists
			if (n < 0)
				return 0;

			// If there are no coins and n is greater than 0, then no solution exists
			if (m <=0 && n >= 1)
				return 0;

			// count is sum of solutions (i) including S[m-1] (ii) excluding S[m-1]
			return count(S, m - 1, n) + count(S, m, n-S[m-1]);
		}
		}
	}
}

