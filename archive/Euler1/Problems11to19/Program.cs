using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems11to19
{
    class Program
    {
        static void Main(string[] args)
        {
            var myProblem = new Problem19();
            Console.WriteLine("the answer is {0:n0} or {0}", myProblem.soln1());
            //Console.WriteLine("the soln2() answer is {0:n0} or {0}", myProblem.soln2());

            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }
    }
}
