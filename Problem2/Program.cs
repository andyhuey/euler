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
		const int max = 4000000;

		public static void Main (string[] args)
		{
			Console.WriteLine ("sum={0}", soln1());		// 4613732
			Console.WriteLine ("sum={0}", soln2());
			Console.WriteLine ("sum={0}", soln3());
			Console.WriteLine ("sum={0}", soln4());

            Console.WriteLine("Press enter...");
            Console.ReadLine();

		}

		public static int soln4()
		{
			//  E(n)=4*E(n-1)+E(n-2).

			int efib1=2, efib2=8, efib3;
			int sum = efib1 + efib2;
			
			var sw = Stopwatch.StartNew();

			efib3 = 4 * efib2 + efib1;
			while (efib3 < max)
			{
				sum += efib3;
				
				efib1 = efib2;
				efib2 = efib3;
				efib3 = 4 * efib2 + efib1;
			}
			sw.Stop();
			Console.WriteLine("elapsed = {0} secs", sw.Elapsed.TotalSeconds);
			return sum;
		}

		public static int soln3()
		{
			// every third number is even...
			int fib1=1, fib2=1, fib3;
			int sum = 0;
			
			var sw = Stopwatch.StartNew();

			fib3 = fib1 + fib2;
			while (fib3 < max)
			{
				sum += fib3;

				fib1 = fib2 + fib3;
				fib2 = fib3 + fib1;
				fib3 = fib1 + fib2;
			}
			sw.Stop();
			Console.WriteLine("elapsed = {0} secs", sw.Elapsed.TotalSeconds);
			return sum;
		}

		public static int soln2()
		{
			int fib1=1, fib2=2;
			int sum = 0;
			
			var sw = Stopwatch.StartNew();
			
			while (fib2 < max)
			{
				if (fib2 % 2 == 0)
					sum += fib2;
				
				int n = fib1 + fib2;
				fib1 = fib2;
				fib2 = n;
			}
			sw.Stop();
			Console.WriteLine("elapsed = {0} secs", sw.Elapsed.TotalSeconds);
			return sum;
		}

		public static int soln1()
		{
			List<int> fib = new List<int>() {1,2};
			int sum = 0;
			
			var sw = Stopwatch.StartNew();
			
			while (fib[fib.Count - 1] < max)
			{
				if (fib[fib.Count - 1] % 2 == 0)
					sum += fib[fib.Count - 1];
				
				int n = fib[fib.Count - 2] + fib[fib.Count - 1];
				fib.Add(n);
			}
			sw.Stop();
			Console.WriteLine("elapsed = {0} secs", sw.Elapsed.TotalSeconds);
			return sum;
		}
	}
}
