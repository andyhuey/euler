﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projects11to19
{
    class Program
    {
        static void Main(string[] args)
        {
            var myProblem = new Problem11();
            Console.WriteLine("the answer is {0:n0}", myProblem.soln1());

            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }
    }
}
