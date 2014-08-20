/*
 * http://projecteuler.net/problem=43
 * Sub-string divisibility
 * Answer: 
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems40to49
{
    class Problem43
    {
        List<string> allPandig;

        public long soln1()
        {
            int ans = 0;
            var sw = Stopwatch.StartNew();
            
            genPandig("");

            Console.WriteLine("generated {0} numbers.", allPandig.Count);
            //foreach (string s in allPandig)
            //    Console.WriteLine(s);

            sw.Stop();
            Console.WriteLine("elapsed: {0} sec", sw.Elapsed.Seconds);
            return ans;
        }

        private void genPandig(string s)
        {
            //Console.WriteLine("Called with {0}.", s);
            // kick it off with the digits from 1-9
            if (s == "")
            {
                allPandig = new List<string>();
                for (char ch = '1'; ch <= '9'; ch++)
                    genPandig(ch.ToString());
                return;
            }
            // if it's 10 digits, we're done.
            if (s.Length == 10)
            {
                allPandig.Add(s);
                return;
            }
            // otherwise, recurse.
            for (char ch = '0'; ch <= '9'; ch++)
            {
                if (s.IndexOf(ch) >= 0)     // already used.
                    continue;
                genPandig(s + ch);
            }
        }
    }
}
