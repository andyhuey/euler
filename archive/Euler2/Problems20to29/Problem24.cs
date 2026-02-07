/*
 * http://projecteuler.net/problem=24
 * Lexicographic permutations
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problems20to29
{
    class Problem24
    {
        string set;
        List<string> perms;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            //set = "012";
            set = "0123456789";
            perms = new List<string>();

            get_perms("");

            //foreach (string s in perms)
            //    Console.WriteLine(s);

            sw.Stop();
            Console.WriteLine("elapsed: {0} sec", sw.Elapsed.Seconds);

            return long.Parse(perms[999999]);
            // elapsed: 3 sec
            // The answer is 2,783,915,460 or 2783915460
        }

        private void get_perms(string so_far)
        {
            if (perms.Count > 1000000)
                return;
            if (so_far.Length == set.Length)
            {
                perms.Add(so_far);
                //Console.WriteLine(so_far);
                if (perms.Count % 5000 == 0)
                    Console.WriteLine("{0} permutations so far...", perms.Count);
                return;
            }
            foreach (char ch in set)
            {
                if (!so_far.Contains(ch))
                {
                    get_perms(so_far + ch);
                }
            }
        }
    }
}
