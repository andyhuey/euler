/*
 * http://projecteuler.net/problem=12
 * What is the value of the first triangle number to have over five hundred divisors?
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problems11to19
{
    public class Problem12
    {
        public long soln1()
        {
            //int loopIterations = 0;
            var sw = Stopwatch.StartNew();
            int triNum = 0;
            int currTriNumVal = 0;
            int nFactors, nLastFactors = 0;
            bool isDone = false;

            while (!isDone)
            {
                triNum++;
                currTriNumVal += triNum;
                // or it could be (n * n+1)/2

                // to have 500 factors, the # must be at least 500^2...
                if (currTriNumVal < 500 * 500)
                    continue;

                nFactors = GetFactors(currTriNumVal).Count();

                if (nFactors > nLastFactors)
                {
                    Console.WriteLine("#{0} = {1} / # of factors={2}",
                        triNum, currTriNumVal, nFactors);
                }

                if (nFactors > 500)
                    isDone = true;

                nLastFactors = nFactors;
                //if (currTriNumVal > 100)
                //    break;
            }

            // show the factors, for curiosity's sake...
            //Console.WriteLine(string.Join(", ",GetFactors(currTriNumVal).ToArray()));

            sw.Stop();
            //Console.WriteLine("Loop iterations: {0:n0}", loopIterations);
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return currTriNumVal;
        }

        private IEnumerable<int> GetFactors(int num)
        {
            for (int f = 1; f * f <= num; f++)
            {
                if (num % f == 0)
                {
                    yield return f;
                    if (f * f != num)
                        yield return num / f;
                }
            }
        }


    }
}
