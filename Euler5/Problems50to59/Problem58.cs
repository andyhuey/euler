/*
 * https://projecteuler.net/problem=58
 * Spiral primes
 * (see problem 28)
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems50to59
{
    class Problem58
    {
        // switch to a HashSet to avoid out-of-memory errors.
        private HashSet<int> primes = new HashSet<int>();
        int nOldMax;
        const int INCR = 100000;
        const int MAX_GRID = 25000;
        enum Direction { Right, Down, Left, Up };

        public Problem58()
        {
            // zero and one aren't prime.
            nOldMax = 2;
        }

        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            // fill in the prime array
            //isPrime(MAX_GRID * MAX_GRID);

            int gridSize = processGrid(MAX_GRID);

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return gridSize;
        }

        private int processGrid(int maxGridSize)
        {
            int nPrimes = 0;
            int nDiagCells = 0;
            int x = 0, y = 0;
            Direction dir = Direction.Right;
            int increment = 1;
            int steps = 0;
            int counter = 1;

            while (counter <= maxGridSize * maxGridSize)
            {
                // set the cell value: (not really necessary)
                //gridValues[x, y] = counter;
                // is this cell on a diagonal?
                if (Math.Abs(x) == Math.Abs(y))
                {
                    nDiagCells++;
                    if (isPrime(counter))
                        nPrimes++;
                }
                // logic to move to next cell:
                steps++;
                switch (dir)
                {
                    case Direction.Right:
                        x++;
                        if (steps == increment)
                        {
                            //Console.WriteLine("steps={0}, increment={1}, x={2}, y={3}, counter={4}", steps, increment, x, y, counter);
                            if (counter > 1)
                            {
                                double ratio = (double)nPrimes / nDiagCells;
                                Console.WriteLine("For grid size {0}, result is {1}/{2} or {3:0}%", increment, nPrimes, nDiagCells, ratio*100);
                                //Console.ReadLine();
                                if (ratio < 0.10)
                                    return increment;
                            }
                            steps = 0;
                            dir = Direction.Up;
                        }
                        break;
                    case Direction.Down:
                        y--;
                        if (steps == increment)
                        {
                            steps = 0;
                            dir = Direction.Right;
                            increment++;
                        }
                        break;
                    case Direction.Left:
                        x--;
                        if (steps == increment)
                        {
                            steps = 0;
                            dir = Direction.Down;
                        }
                        break;
                    case Direction.Up:
                        y++;
                        if (steps == increment)
                        {
                            steps = 0;
                            dir = Direction.Left;
                            increment++;
                        }
                        break;

                }
                counter++;
            }
            // we failed...
            return 0;
        }

        private bool isPrime(int n)
        {
            if (n < 0)
                return false;

            if (n < nOldMax)
                return primes.Contains(n);

            int p = 2;      // NOTE: we shouldn't always start at 2. I'm repeating work I've already done...
            int nPrimeMax = nOldMax;
            do
            {
                nPrimeMax += INCR;
            } while (nPrimeMax < n);

            int sqrt_max = (int)Math.Floor(Math.Sqrt(nPrimeMax));

            Console.WriteLine("Filling in primes from {0} to {1}.", nOldMax, nPrimeMax);

            for (int i = nOldMax; i < nPrimeMax; i++)
                primes.Add(i);

            while (p <= sqrt_max)
            {
                // cross out all the multiple of p.
                for (int i = p * p; i < nPrimeMax; i += p)
                {
                    primes.Remove(i);
                }

                // get the next p.
                do
                {
                    p++;
                } while (!primes.Contains(p));
            }
            nOldMax = nPrimeMax;
            // now, check the number we asked for.
            return primes.Contains(n);
        }
    }
}
