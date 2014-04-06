using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projects1to10
{
    class Program
    {
        static void Main(string[] args)
        {
            var myProblem = new Problem6();
            Console.WriteLine("the answer is {0:n0}", myProblem.soln_pdf());

            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }
    }
}
