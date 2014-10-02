/*
 * https://projecteuler.net/problem=61
 * Cyclical figurate numbers
 * (see also problem 45)
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems60to69
{
    class Problem61
    {
        enum FigEnum
        {
            Triangle = 3,
            Square = 4,
            Pentagon = 5,
            Hexagon = 6,
            Heptagon = 7,
            Octagon = 8
        }

        class FigurateNum
        {
            public int Num { get; private set; }

            private Dictionary<FigEnum, bool> isFig;

            public FigurateNum(int n)
            {
                this.Num = n;
                isFig = new Dictionary<FigEnum, bool>();
            }

            public bool getIsFig(FigEnum k)
            {
                if (isFig.ContainsKey(k))
                    return isFig[k];
                else
                    return false;
            }

            public void setIsFig(FigEnum k, bool b)
            {
                isFig[k] = b;
            }

            public string getFirstTwoDigits()
            {
                int n = this.Num / 100;
                return n.ToString();
            }

            public string getLastTwoDigits()
            {
                int n = this.Num % 100;
                return n.ToString("D2");
            }

            public override string ToString()
            {
                //return base.ToString();
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0}: ", this.Num);
                foreach (FigEnum k in Enum.GetValues(typeof(FigEnum)))
                {
                    if (isFig.ContainsKey(k))
                        sb.AppendFormat("{0}: {1} / ", k, isFig[k]);
                }
                return sb.ToString();
            }
        }

        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            // we want to start by making a list of all the 4-digit fig #s.
            List<FigurateNum> myFigNums = new List<FigurateNum>();

            foreach (FigEnum k in Enum.GetValues(typeof(FigEnum)))
            {
                int n = 1;
                // skip to 1001.
                while (getFigurateNum(k, ++n) < 1000) ;
                // now start saving them.
                int p = getFigurateNum(k, n);
                //Console.WriteLine("{0}, {1} -> {2}", k, n, p);
                while (p < 10000)
                {
                    var fn = myFigNums.FirstOrDefault(x => x.Num == p);
                    if (fn == null)
                    {
                        fn = new FigurateNum(p);
                        myFigNums.Add(fn);
                    }
                    fn.setIsFig(k, true);

                    n++;
                    p = getFigurateNum(k, n);
                }
                //Console.WriteLine("{0}, {1} -> {2}", k, n, p);
            }

            //foreach (var fn in myFigNums)
            //{
            //    //Console.WriteLine(fn.ToString());
            //    Console.WriteLine("{0} {1} - {2}", fn.getFirstTwoDigits(), fn.getLastTwoDigits(), fn.ToString());
            //}

            //foreach (FigEnum k in Enum.GetValues(typeof(FigEnum)))
            //{
            //    Console.WriteLine("{0}: {1} numbers", k, myFigNums.Where(x => x.getIsFig(k)).Count());
            //}

            // not sure where to do with this...
            //var candidates = from x in myFigNums where x.getIsFig(FigEnum.Triangle) select x.Num;
            //candidates = 
            //    from x in myFigNums where !candidates.Contains(x.Num)


            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return 0;
        }

        private int getFigurateNum(FigEnum k, int n)
        {
            switch (k)
            {
                case FigEnum.Triangle:
                    return n * (n + 1) / 2;
                case FigEnum.Square:
                    return n * n;
                case FigEnum.Pentagon:
                    return n * (3 * n - 1) / 2;
                case FigEnum.Hexagon:
                    return n * (2 * n - 1);
                case FigEnum.Heptagon:
                    return n * (5 * n - 3) / 2;
                case FigEnum.Octagon:
                    return n * (3 * n - 2);
                default:
                    throw new ArgumentOutOfRangeException("k", "k must be a valid FigEnum.");
            }
        }

        private long triangleNum(int n)
        {
            return n * (n + 1) / 2;
        }

        private bool isTriangleNum(int x)
        {
            // from http://www.mathblog.dk/project-euler-42-triangle-words/
            double dn = (Math.Sqrt(8 * x + 1) - 1) / 2;
            return dn == (int)dn;
        }

        private long squareNum(int n)
        {
            return n * n;
        }

        private bool isSquareNum(long n)
        {
            double dn = Math.Sqrt(n);
            return dn == (int)dn;
        }

        private long pentagonNum(int n)
        {
            return n * (3 * n - 1) / 2;
        }

        private bool isPentagonNum(long x)
        {
            // from http://www.mathblog.dk/project-euler-44-smallest-pair-pentagonal-numbers/
            double dn = (Math.Sqrt(24 * x + 1) + 1) / 6;
            return dn == (int)dn;
        }

        private long hexagonNum(int n)
        {
            return n * (2 * n - 1);
        }

        private bool isHexagonNum(long x)
        {
            // from http://en.wikipedia.org/wiki/Hexagonal_number
            double dn = (Math.Sqrt(8 * x + 1) + 1) / 4;
            return dn == (int)dn;
        }

        private long heptagonNum(int n)
        {
            return n * (5 * n - 3) / 2;
        }

        private long octagonNum(int n)
        {
            return n * (3 * n - 2);
        }
    }
}
