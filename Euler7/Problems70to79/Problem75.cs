/*
 * Problem 75
 * https://projecteuler.net/problem=75
 * Singular Integer Right Triangles
 */
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems70to79
{
    internal class Problem75
    {
        public static void Run()
        {
            Console.WriteLine("Started at {0}", DateTime.Now);
            var myProblem = new Problem75();
            //int lMax = 50;          // 6
            //int lMax = 120;         // 13
            int lMax = 1500000;       // 161667
            //int ans = myProblem.Soln1(lMax);
            int ans = myProblem.Soln2(lMax);
            //int ans = myProblem.Soln3(lMax);
            Console.WriteLine("The answer is {0}.", ans);
        }

        private int Soln1(int lMax)
        {
            int nTotal = 0;
            for (int i = 1; i <= lMax; i++)
                if (FindIntRtTriangles(i) == 1)
                    nTotal++;
            return nTotal;
        }
        
        private int FindIntRtTriangles(int L)
        {
            List<Triangle> trianges = new List<Triangle>();
            int nFound = 0;

            for (int x = 1; x < L; x++)
                for (int y = x+1; y < L-x; y++)
                {
                    int z = L - x - y;
                    //Console.WriteLine("trying: ({0}, {1}, {2})", x, y, z);
                    if (Triangle.IsValidTriangle(x, y, z))
                    {
                        Triangle t = new Triangle(x, y, z);
                        if (t.IsRightAngle())
                        {
                            // got it.
                            trianges.Add(t);
                            //Console.WriteLine("{0}cm: ({1}, {2}, {3})", L, x, y, z);
                            nFound++;
                        }
                    }
                }
            if (nFound > 0)
            {
                Console.Write("{0}cm: ", L);
                foreach (var t in trianges)
                    Console.Write(t.ToString());
                Console.WriteLine();
            }
            return nFound;
        }

        private int Soln2(int lMax)
        {
            List<Triangle>[] trianglesOfL = new List<Triangle>[lMax + 1];
            int[] nTrianglesOfL = new int[lMax + 1];

            for (int i = 1; i <= lMax; i++)
                trianglesOfL[i] = new List<Triangle>();

            var sqrtOflMax = Math.Sqrt(lMax);
            Console.WriteLine("Checking from 1 to {0} for L max = {1}...", sqrtOflMax, lMax);

            for (int n = 1; n < sqrtOflMax; n++)
            {
                //if (n % 100 == 0)
                //    Console.WriteLine($"  n = {n}...");
                for (int m = n + 1; m < sqrtOflMax; m++)
                {
                    int a = (m * m - n * n);
                    int b = (2 * m * n);
                    int c = (m * m + n * n);
                    if (a < lMax && b < lMax && c < lMax)
                    {
                        long L = a + b + c;
                        if (L <= lMax && Triangle.IsValidTriangle(a, b, c))
                        {
                            Triangle t = new Triangle(a, b, c);
                            if (AddTriangle(trianglesOfL[L], t))
                            {
                                nTrianglesOfL[L]++;
                                int k = 1;
                                //Console.WriteLine($"{L}cm: {t} - k={k}, n={n}, m={m}");
                                while (L <= lMax)
                                {
                                    // and now let's add multiples of this guy...
                                    k++;
                                    Triangle t2 = new Triangle(a * k, b * k, c * k);
                                    L = t2.L;
                                    if (L <= lMax)
                                    {
                                        if (AddTriangle(trianglesOfL[L], t2))
                                            nTrianglesOfL[L]++;
                                    }
                                }   // end while L
                            }
                        }
                    }
                } // end for m
            } // end for n

            int nTotal = GetTriangleCount(lMax, trianglesOfL, nTrianglesOfL);
            return nTotal;
        }

        private int GetTriangleCount(int lMax, List<Triangle>[] trianglesOfL, int[] nTrianglesOfL)
        {
            Console.WriteLine("Getting triangle count...");
            int nTotal = 0;
            bool tooMuchOutput = false;
            for (int i = 1; i <= lMax; i++)
                if (nTrianglesOfL[i] >= 1)
                {
                    if (!tooMuchOutput)
                    {
                        Console.Write("{0}cm: {1} triangles: ", i, nTrianglesOfL[i]);
                        foreach (Triangle t in trianglesOfL[i])
                            Console.Write(t.ToString());
                        Console.WriteLine();
                        if (nTotal > 20)
                        {
                            tooMuchOutput = true;
                            Console.WriteLine("(...and so on.)");
                        }
                    }
                    if (nTrianglesOfL[i] == 1)
                        nTotal++;
                }

            return nTotal;
        }

        private bool AddTriangle(List<Triangle> triangles, Triangle t)
        {
            //if (triangles is null)
            //    triangles = new List<Triangle>();
            if (!triangles.Any(t1 => t1.Equals(t)))
            {
                triangles.Add(t);
                return true;
            }
            return false;
        }

        private int Soln3(int lMax)
        {
            // from problem 39.
            List<Triangle>[] trianglesOfL = new List<Triangle>[lMax + 1];
            int[] nTrianglesOfL = new int[lMax + 1];

            for (int i = 1; i <= lMax; i++)
                trianglesOfL[i] = new List<Triangle>();

            for (long a = 1; a < lMax; a++)
            {
                if (a % 100 == 0)
                    Console.WriteLine($"a = {a}...");

                for (long b = a; b < lMax; b++)
                {
                    if (a + b >= lMax)
                        continue;

                    double c = Math.Sqrt((a * a) + (b * b));
                    if (c != Math.Floor(c))     // must be a whole #.
                        continue;
                    if (c < 1)                  // zero doesn't count.
                        continue;
                    long c1 = Convert.ToInt64(c);
                    long L = a + b + c1;
                    if (L > lMax)
                        continue;

                    Triangle t = new Triangle(a, b, c1);
                    if (AddTriangle(trianglesOfL[L], t))
                        nTrianglesOfL[L]++;
                }
            }
            int nTotal = GetTriangleCount(lMax, trianglesOfL, nTrianglesOfL);
            return nTotal;

        }
    }

    internal struct Triangle
    {
        public long X { get; }
        public long Y { get; }
        public long Z { get; }

        public long L { get { return X + Y + Z; } }

        public Triangle(long x, long y, long z)
        {
            if (x <= 0 || y <= 0 || z <= 0)
                throw new ArgumentException("Sides of a triangle must be positive numbers.");
            if (x + y <= z || x + z <= y || y + z <= x)
                throw new ArgumentException("The sum of the lengths of any two sides of a triangle must be greater than the length of the third side.");

            X = x;
            Y = y;
            Z = z;
        }

        public static bool IsValidTriangle(long x, long y, long z)
        {
            if (x <= 0 || y <= 0 || z <= 0)
                return false;
            if (x + y <= z || x + z <= y || y + z <= x)
                return false;
            return true;
        }

        public bool IsRightAngle()
        {
            // x² + y² = z²
            return (X * X + Y * Y == Z * Z);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Triangle)
            {
                Triangle t = (Triangle)obj;
                long[] thisSides = new long[] { X, Y, Z };
                long[] otherSides = new long[] { t.X, t.Y, t.Z };
                Array.Sort(thisSides);
                Array.Sort(otherSides);
                return thisSides.SequenceEqual(otherSides);
                //return (t.X == X && t.Y == Y && t.Z == Z);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (X, Y, Z).GetHashCode();
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z}) ";
        }
    }
}
