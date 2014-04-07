/*
 * http://projecteuler.net/problem=28
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems20to29
{
    class Problem28
    {
        const int GRID_SIZE = 5;

        public long soln1()
        {
            int[,] gridValues = new int[GRID_SIZE,GRID_SIZE];
            int x = 0, y = 0;
            int direction = 1;
            int increment = 1;
            long sumOfDiags = 0;
            int counter = 1;

            while (counter < GRID_SIZE * GRID_SIZE)
            {
                gridValues[x, y] = counter;
                if (Math.Abs(x) == Math.Abs(y))
                    sumOfDiags += counter;
                // logic to move to next cell goes here...
                counter++;
            }
            return sumOfDiags;
        }
    }
}
