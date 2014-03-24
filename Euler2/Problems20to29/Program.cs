using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems20to29
{
    class Program
    {
        static void Main(string[] args)
        {
            var myProblem = new Problem26();
            Console.WriteLine("The answer is {0:n0} or {0}", myProblem.soln1());
            //Console.WriteLine("the soln2() answer is {0:n0} or {0}", myProblem.soln2());
            //Console.WriteLine("the soln3() answer is {0:n0} or {0}", myProblem.soln3());
            //Console.WriteLine("the soln4() answer is {0:n0} or {0}", myProblem.soln4());

            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }
    }
}
