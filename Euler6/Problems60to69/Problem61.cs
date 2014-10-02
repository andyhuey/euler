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
            //Stack<FigurateNum> candidates = new Stack<FigurateNum>();
            var q1 = from x in myFigNums where x.getIsFig(FigEnum.Triangle) select x;
            foreach (var c1 in q1)
            {
                var q2 = 
                    from x in myFigNums 
                    where x.getFirstTwoDigits() == c1.getLastTwoDigits() 
                    && x.Num != c1.Num
                    select x;
                foreach (var c2 in q2)
                {
                    var q3 =
                        from x in myFigNums
                        where x.getFirstTwoDigits() == c2.getLastTwoDigits()
                        && x.Num != c1.Num
                        && x.Num != c2.Num
                        select x;
                    foreach (var c3 in q3)
                    {
                        var q4 =
                            from x in myFigNums
                            where x.getFirstTwoDigits() == c3.getLastTwoDigits()
                            && x.Num != c1.Num
                            && x.Num != c2.Num
                            && x.Num != c3.Num
                            select x;
                        foreach (var c4 in q4)
                        {
                            var q5 =
                                from x in myFigNums
                                where x.getFirstTwoDigits() == c4.getLastTwoDigits()
                                && x.Num != c1.Num
                                && x.Num != c2.Num
                                && x.Num != c3.Num
                                && x.Num != c4.Num
                                select x;
                            foreach (var c5 in q5)
                            {
                                var q6 =
                                    from x in myFigNums
                                    where x.getFirstTwoDigits() == c5.getLastTwoDigits()
                                    && x.Num != c1.Num
                                    && x.Num != c2.Num
                                    && x.Num != c3.Num
                                    && x.Num != c4.Num
                                    && x.Num != c5.Num
                                    select x;
                                foreach (var c6 in q6)
                                {
                                    //Console.WriteLine("{0} {1} {2} {3} {4} {5}", c1.Num, c2.Num, c3.Num, c4.Num, c5.Num, c6.Num);
                                    bool gotIt = true;
                                    HashSet<FigurateNum> candidateSet = new HashSet<FigurateNum>();
                                    candidateSet.Add(c1);
                                    candidateSet.Add(c2);
                                    candidateSet.Add(c3);
                                    candidateSet.Add(c4);
                                    candidateSet.Add(c5);
                                    candidateSet.Add(c6);
                                    foreach (FigEnum k in Enum.GetValues(typeof(FigEnum)))
                                    {
                                        if (!candidateSet.Any(c => c.getIsFig(k)))
                                            gotIt = false;
                                    }
                                    if (gotIt)
                                        Console.WriteLine("{0} {1} {2} {3} {4} {5}", c1.Num, c2.Num, c3.Num, c4.Num, c5.Num, c6.Num);
                                }
                            }
                        }
                    }
                }
            }


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
