using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems70to79
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var myProblem = new Problem73(8);
            Console.WriteLine("The answer for MAX D {0} is {1:n0} or {1}", 
                myProblem.MaxD,
                myProblem.soln1());

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }
    }
}
