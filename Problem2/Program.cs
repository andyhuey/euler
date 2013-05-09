// http://projecteuler.net/problem=2
// sum of even-valued Fibonacci numbers
// ajh 2013-05-08

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Problem2
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			List<int> fib = new List<int>() {1,2};
			int sum = 0;
			int max = 4000000;
			var sw = Stopwatch.StartNew();

			while (fib[fib.Count - 1] < max)
			{
				if (fib[fib.Count - 1] % 2 == 0)
					sum += fib[fib.Count - 1];

				int n = fib[fib.Count - 2] + fib[fib.Count - 1];
				fib.Add(n);
			}
			sw.Stop();

			Console.WriteLine ("sum={0}", sum);		// 4613732
			Console.WriteLine("elapsed = {0} secs", sw.Elapsed.TotalSeconds);
		}
	}
}
