/*
 * http://projecteuler.net/problem=28
 * Number spiral diagonals
 * The answer is: 669,171,001
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
        // grid size should be an odd number.
        const int GRID_SIZE = 1001;
        enum Direction { Right, Down, Left, Up };

        public long soln1()
        {
            // oops, this wouldn't actually work with negative indices, dummy:
            //int[,] gridValues = new int[GRID_SIZE,GRID_SIZE];
            int x = 0, y = 0;
            Direction dir = Direction.Right;
            int increment = 1;
            int steps = 0;
            long sumOfDiags = 0;
            int counter = 1;

            while (counter <= GRID_SIZE * GRID_SIZE)
            {
                // set the cell value: (not really necessary)
                //gridValues[x, y] = counter;
                // is this cell on a diagonal?
                if (Math.Abs(x) == Math.Abs(y))
                    sumOfDiags += counter;
                // logic to move to next cell:
                steps++;
                switch (dir)
                {
                    case Direction.Right:
                        x++;
                        if (steps == increment)
                        {
                            steps = 0;
                            dir = Direction.Down;
                        }
                        break;
                    case Direction.Down:
                        y--;
                        if (steps == increment)
                        {
                            steps = 0;
                            dir = Direction.Left;
                            increment++;
                        }
                        break;
                    case Direction.Left:
                        x--;
                        if (steps == increment)
                        {
                            steps = 0;
                            dir = Direction.Up;
                        }
                        break;
                    case Direction.Up:
                        y++;
                        if (steps == increment)
                        {
                            steps = 0;
                            dir = Direction.Right;
                            increment++;
                        }
                        break;

                }
                counter++;
            }
            return sumOfDiags;
        }
    }
}
