/*
 * http://projecteuler.net/problem=33
 * Digit canceling fractions
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems30to39
{
    class Problem33
    {
        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            int n1, n2, d1, d2;

            for (int n = 11; n <= 99; n++)
            {
                if (n % 10 == 0)
                    continue;
                //Console.WriteLine(n);
                for (int d = n + 1; d <= 99; d++)
                {
                    if (d % 10 == 0)
                        continue;
                    
                    n1 = n / 10;
                    n2 = n % 10;
                    d1 = d / 10;
                    d2 = d % 10;

                    // do they have a shared digit?
                    if (n1 != d2 && n2 != d1)
                        continue;

                    // I know this isn't quite right...
                    float f1 = (float)n / d;
                    float f2 = (float)n1 / d2;
                    float f3 = (float)n2 / d1;
                    if (f1 == f2 || f1 == f3)
                    {
                        // we've got it, I think.
                        Console.WriteLine("{0}{1} / {2}{3}", n1, n2, d1, d2);
                    }
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.Milliseconds);
            return 0;
        }
    }
}
