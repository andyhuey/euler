/*
 * http://projecteuler.net/problem=68
 * Magic 5-gon ring
 * (starting with 3-gon ring)
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems60to69
{
    class ThreeGonRing
    {
        int[] node;
        public ThreeGonRing (int[] node)
	    {
            Debug.Assert(node.Length == 6);
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
                    return new int[3] { node[5], node[4], node[1] };
            }
            throw new ArgumentOutOfRangeException("n must be in 0-2.");
        }

        public int getMagicRingSum()
        {
            // sum of each tuple must be the same. return -1 if not magic
            int s1 = getTuple(0).Sum();
            if (s1 == getTuple(1).Sum() && s1 == getTuple(2).Sum())
                return s1;
            else
                return -1;
        }

        public bool isValidRing()
        {
            // must be one each of 1..6.
            for (int i = 1; i <= 6; i++)
            {
                if (node.Where(n => n == i).Count() != 1)
                    return false;
            }
            return true;
        }

        public bool isRotationOf(ThreeGonRing ring)
        {
            // 0,1,2 -> 1,2,0
            if (this.getTuple(0).SequenceEqual(ring.getTuple(1))
                && this.getTuple(1).SequenceEqual(ring.getTuple(2))
                && this.getTuple(2).SequenceEqual(ring.getTuple(0)))
                return true;
            // 0,1,2 -> 2,0,1
            if (this.getTuple(0).SequenceEqual(ring.getTuple(2))
                && this.getTuple(1).SequenceEqual(ring.getTuple(0))
                && this.getTuple(2).SequenceEqual(ring.getTuple(1)))
                return true;
            // otherwise:
            return false;
        }

        public string getDigitString()
        {
            return string.Join<int>("", this.getTuple(0)) + 
                string.Join<int>("", this.getTuple(1)) + 
                string.Join<int>("", this.getTuple(2));
        }

        public override string ToString()
        {
            //return base.ToString();
            return string.Join<int>(", ", this.getTuple(0)) + "; " +
                string.Join<int>(", ", this.getTuple(1)) + "; " +
                string.Join<int>(", ", this.getTuple(2));
            
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
            List<ThreeGonRing> magicRings = new List<ThreeGonRing>();

            foreach (var p in getAllPerms(p1))
            {
                //Console.WriteLine(string.Join<int>(", ", p));
                var ring = new ThreeGonRing(p.ToArray());
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
            if (perm.Count < 6)
            {
                for (int i = 1; i <= 6; i++)
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
