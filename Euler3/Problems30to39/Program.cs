﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems30to39
{
    class Program
    {
        static void Main(string[] args)
        {
			var myProblem = new Problem36();
            Console.WriteLine("The answer is {0:n0} or {0}", myProblem.soln1());

            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }
    }
}
