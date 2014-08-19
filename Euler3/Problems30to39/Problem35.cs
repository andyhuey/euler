/*
 * http://projecteuler.net/problem=35
 * Circular primes
 * How many circular primes are there below one million?
 * The answer is 55.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems30to39
{
    public class Problem35
    {
        const int nPrimeMax = 1000000;
        bool[] primes;

        private void getPrimes()
        {
            // get primes (from Problem 10)
            primes = new bool[nPrimeMax];
            int p = 2;
            int sqrt_max = (int)Math.Floor(Math.Sqrt(nPrimeMax));

            // initialize all to true
            for (int i = 2; i < nPrimeMax; i++)
                primes[i] = true;

            while (p <= sqrt_max)
            {
                // cross out all the multiple of p.
                for (int i = p * p; i < nPrimeMax; i += p)
                {
                    primes[i] = false;
                }

                // get the next p.
                do
                {
                    p++;
                } while (!primes[p]);
            }
        }

        private List<int> getCircularNums(int n)
        {
            // return a list of all the circular variations on a number, e.g. 123, 231, 312.
            List<int> circ = new List<int>();
            char[] ca = n.ToString().ToCharArray();
            for (int i = 0; i < ca.Length; i++)
            {
                string s = "";
                for (int j = 0; j < ca.Length; j++)
                {
                    s += ca[(i + j) % ca.Length];
                }
                circ.Add(Int32.Parse(s));
            }
            return circ;
        }

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            int counter = 0;

            //var l = this.getCircularNums(123456);
            //foreach (var i in l)
            //    Console.WriteLine(i);
            //return 0;

            this.getPrimes();

            for (int i = 1; i < nPrimeMax; i++)
            {
                if (!primes[i])
                    continue;
                var circs = this.getCircularNums(i);
                if (circs.All(x => primes[x]))
                {
                    Console.WriteLine(i);
                    counter++;
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return counter;
        }
    }
}
