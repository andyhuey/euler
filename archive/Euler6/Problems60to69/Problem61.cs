/*
 * https://projecteuler.net/problem=61
 * Cyclical figurate numbers
 * (see also problem 45)
 * 
 * 8256: Triangle: True /
 * 5625: Square: True /
 * 2512: Heptagon: True /
 * 1281: Octagon: True /
 * 8128: Triangle: True / Hexagon: True /
 * 2882: Pentagon: True /
 * The answer is 28684
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

            public FigEnum? getHighestFig()
            {
                var q = from k in isFig where k.Value == true orderby k.Key descending select k.Key;
                if (!q.Any())
                    return null;
                return q.First();
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

        List<FigurateNum> myFigNums;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            long sumOfNums = 0;

            // we want to start by making a list of all the 4-digit fig #s.
            myFigNums = new List<FigurateNum>();
            this.popFigNums();

            var q1 = from x in myFigNums where x.getHighestFig() == FigEnum.Triangle select x;
            foreach (var c1 in q1)
            {
                List<FigurateNum> candidateSet = new List<FigurateNum>();
                candidateSet.Add(c1);
                long n = processSubset(candidateSet);
                if (n > 0)
                    sumOfNums = n;
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return sumOfNums;
        }

        private void popFigNums()
        {
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
            }
        }

        private long processSubset(List<FigurateNum> candidateSet)
        {
            if (candidateSet.Count < 6)
            {
                long rv = 0;
                FigurateNum c1 = candidateSet.Last();
                var q2 = 
                    from x in myFigNums 
                    where x.getFirstTwoDigits() == c1.getLastTwoDigits() 
                    && !candidateSet.Any(c => c.Num == x.Num)
                    select x;
                foreach (var c2 in q2)
                {
                    List<FigurateNum> nextCandidateSet = new List<FigurateNum>(candidateSet);
                    nextCandidateSet.Add(c2);
                    long n = processSubset(nextCandidateSet);
                    if (n > 0)
                        rv = n;
                }
                return rv;
            }
            else
            {
                // we have all 6 numbers. check and see if we've got what we need...
                // check wrap from #6 to #1...
                FigurateNum c1 = candidateSet.First();
                FigurateNum c6 = candidateSet.Last();
                if (c6.getLastTwoDigits() != c1.getFirstTwoDigits())
                    return 0;
                // do we have one of each?
                bool gotIt = true;
                foreach (FigEnum k in Enum.GetValues(typeof(FigEnum)))
                {
                    if (!candidateSet.Any(c => c.getHighestFig() == k))
                        gotIt = false;
                }

                if (gotIt)
                {
                    foreach (var c in candidateSet)
                        Console.WriteLine(c);
                    Console.WriteLine("-----");
                    return candidateSet.Sum(c => c.Num);
                }
                return 0;   // nope.
            }
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

    }
}
