/*
 * http://projecteuler.net/problem=68
 * Magic 5-gon ring
 * The max digit string is 6531031914842725.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems60to69
{
    class FiveGonRing
    {
        int[] node;
        public FiveGonRing (int[] node)
	    {
            // we need an array of ten numbers to start.
            Debug.Assert(node.Length == 10);
            this.node = node;
	    }

        private int[] getTuple(int n)
        {
            switch (n)
            {
                case 0:
                    return new int[3] { node[0], node[1], node[2] };
                case 1:
                    return new int[3] { node[3], node[2], node[4] };
                case 2:
                    return new int[3] { node[5], node[4], node[6] };
                case 3:
                    return new int[3] { node[7], node[6], node[8] };
                case 4:
                    return new int[3] { node[9], node[8], node[1] };
            }
            throw new ArgumentOutOfRangeException("n must be in 0-4.");
        }

        public int getMagicRingSum()
        {
            // sum of each tuple must be the same. return -1 if not magic.
            int s1 = getTuple(0).Sum();
            if (s1 == getTuple(1).Sum()
                && s1 == getTuple(2).Sum()
                && s1 == getTuple(3).Sum()
                && s1 == getTuple(4).Sum())
                return s1;
            else
                return -1;
        }

        public bool isValidRing()
        {
            // must be one each of 1..10.
            for (int i = 1; i <= 10; i++)
            {
                if (node.Where(n => n == i).Count() != 1)
                    return false;
            }
            return true;
        }

        private bool checkSeqEq(int[] t1, int[] t2, FiveGonRing ring)
        {
            Debug.Assert(t1.Length == t2.Length);
            for (int i = 0; i < t1.Length; i++)
                if (!this.getTuple(t1[i]).SequenceEqual(ring.getTuple(t2[i])))
                    return false;
            return true;
        }

        public bool isRotationOf(FiveGonRing ring)
        {
            // I'm sure there's a much better way of doing this...
            int[] t1 = new int[] { 0, 1, 2, 3, 4 };
            // 0,1,2,3,4 -> 1,2,3,4,0
            if (this.checkSeqEq(t1, new int[] { 1, 2, 3, 4, 0 }, ring))
                return true;
            // 0,1,2,3,4 -> 2,3,4,0,1
            if (this.checkSeqEq(t1, new int[] { 2, 3, 4, 0, 1 }, ring))
                return true;
            // 0,1,2,3,4 -> 3,4,0,1,2
            if (this.checkSeqEq(t1, new int[] { 3, 4, 0, 1, 2 }, ring))
                return true;
            // 0,1,2,3,4 -> 4,0,1,2,3
            if (this.checkSeqEq(t1, new int[] { 4, 0, 1, 2, 3 }, ring))
                return true;
            // otherwise:
            return false;
        }

        public string getDigitString()
        {
            // get a string with all the digits, in order.
            return string.Join<int>("", this.getTuple(0)) +
                string.Join<int>("", this.getTuple(1)) +
                string.Join<int>("", this.getTuple(2)) +
                string.Join<int>("", this.getTuple(3)) +
                string.Join<int>("", this.getTuple(4));
        }

        public override string ToString()
        {
            // a nicely-formatted version of the data.
            return string.Join<int>(", ", this.getTuple(0)) + "; " +
                string.Join<int>(", ", this.getTuple(1)) + "; " +
                string.Join<int>(", ", this.getTuple(2)) + "; " +
                string.Join<int>(", ", this.getTuple(3)) + "; " +
                string.Join<int>(", ", this.getTuple(4));
            
        }
    }

    class Problem68
    {
        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            //// invalid.
            //var ring = new ThreeGonRing(new int[6] { 1, 2, 3, 4, 5, 5 });
            //Console.WriteLine("{0} - Valid? - {1} / Magic? - {2}", ring.ToString(), ring.getMagicRingSum(), ring.isMagicRing());

            //// valid, not magic.
            //ring = new ThreeGonRing(new int[6] { 1, 2, 3, 4, 5, 6 });
            //Console.WriteLine("{0} - Valid? - {1} / Magic? - {2}", ring.ToString(), ring.getMagicRingSum(), ring.isMagicRing());

            //// magic!
            //ring = new ThreeGonRing(new int[6] { 4, 3, 2, 6, 1, 5 });
            //Console.WriteLine("{0} - Valid? - {1} / Magic? - {2}", ring.ToString(), ring.getMagicRingSum(), ring.isMagicRing());

            // messing with permutations.
            List<int> p1 = new List<int>();
            int nPerms = 0;
            int nMagic = 0;
            List<FiveGonRing> magicRings = new List<FiveGonRing>();

            //Console.WriteLine("There are {0:n0} permutations to consider.", getAllPerms(p1).Count());
            
            foreach (var p in getAllPerms(p1))
            {
                //Console.WriteLine(string.Join<int>(", ", p));
                var ring = new FiveGonRing(p.ToArray());
                if (!ring.isValidRing())
                {
                    throw new Exception(string.Format("{0} is not a valid ring.", ring.ToString()));
                }
                int s = ring.getMagicRingSum();
                if (s > 0)
                {
                    if (!magicRings.Any(r => ring.isRotationOf(r)))
                    {
                        //Console.WriteLine("{0} is a magic ring, with sum {1}.", ring.ToString(), s);
                        nMagic++;
                        magicRings.Add(ring);
                    }
                }
                nPerms++;
            }

            // get rid of any rings where the length of the digit string isn't 16.
            magicRings.RemoveAll(x => x.getDigitString().Length != 16);

            foreach(var ring in magicRings.OrderBy(x => x.getMagicRingSum()))
            {
                Console.WriteLine("{0} is a magic ring, with sum {1}.", ring.ToString(), ring.getMagicRingSum());
            }

            Console.WriteLine("{0} permutations generated.", nPerms);
            Console.WriteLine("{0} magic rings generated.", nMagic);

            Console.WriteLine("The max digit string is {0}.", magicRings.Max(x => x.getDigitString()));

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);

            return 0;
        }

        private IEnumerable<List<int>> getAllPerms(List<int> perm)
        {
            if (perm.Count < 10)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (!perm.Contains(i))
                    {
                        var p2 = new List<int>(perm);
                        p2.Add(i);
                        foreach (var p in getAllPerms(p2))
                            yield return p;
                    }
                }
            }
            else
            {
                yield return perm;
            }

            //IEnumerable<int> n1 = Enumerable.Range(1, 6);
        }

    }
}
