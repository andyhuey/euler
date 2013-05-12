// http://projecteuler.net/problem=1
// ajh 2013-05-08
using System;

namespace Projects1to10
{
	class Problem1
	{
        //public static void Main (string[] args)
        //{
        //    Console.WriteLine("sum={0}", soln1());
        //    Console.WriteLine("sum={0}", soln2());
        //    Console.WriteLine("sum={0}", soln3());
			
        //    Console.WriteLine ("Press enter...");
        //    Console.ReadLine();
        //    // sum=233168
        //}

		static int soln3()
		{
			return sumDivByN(3,999) + sumDivByN(5,999) - sumDivByN(15,999);
		}

		static int sumDivByN(int n, int target)
		{
			int p = target / n;
			//Console.WriteLine("{0} -> {1}", p, n*(p*(p+1)) / 2);
			return n*(p*(p+1)) / 2;
		}

		static int soln2()
		{
			int i, sum;
			sum = 0;
			for (i = 0; i < 1000; i += 3)
			{
				sum += i;
			}
			for (i = 0; i < 1000; i += 5)
			{
				if (i % 3 != 0)
					sum += i;
			}
			return sum;
		}

		static int soln1()
		{
			int i, sum;
			
			sum = 0;
			i = 0;
			while (i < 1000)
			{
				if (i%3==0 || i%5==0)
					sum += i;
				i++;
			}
			return sum;
		}
	}
}
