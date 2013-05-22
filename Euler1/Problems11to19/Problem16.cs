/*
 * http://projecteuler.net/problem=16
 * What is the sum of the digits of the number 2^1000?
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Numerics;

namespace Problems11to19
{
    class Problem16
    {
        int max_power = 15;

        public long soln1()
        {
            int pow;
            int value = 2;

            for (pow = 2; pow <= max_power; pow++)
            {
                value = value + value;
            }

            return value;
        }
    }
}
