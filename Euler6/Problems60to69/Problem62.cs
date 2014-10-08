/*
 * https://projecteuler.net/problem=62
 * Cubic permutations
 * Find the smallest cube for which exactly five permutations of its digits are cube.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problems60to69
{
    class Problem62
    {
        public long soln1()
        {
            var sw = Stopwatch.StartNew();

            //Console.WriteLine(is_cube(3 * 3 * 3));
            //Console.WriteLine(is_cube(12 * 12 * 12));
            //Console.WriteLine(is_cube(7 * 7 * 7));
            //Console.WriteLine(is_cube(60));
            //return 0;
            
            var my_perms = this.get_permutations("41063625");
            foreach (var s in my_perms)
            {
                long l = Convert.ToInt64(s);
                if (is_cube(l))
                    Console.WriteLine(s);
            }
            //Console.WriteLine("# of perms: {0}", my_perms.Count());

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return 0;
        }

        private IEnumerable<string> get_permutations(string s)
        {
            // get all distinct permutations.
            return this.get_perms("", s).Distinct();
        }
        
        private IEnumerable<string> get_perms(string so_far, string remains)
        {
            // this should return all the permutations of a string, without worrying about uniqueness.
            if (remains == "")
                yield return so_far;
            for (int i = 0; i < remains.Length; i++)
            {
                char ch = remains[i];
                string new_remains = remains.Remove(i, 1);
                foreach (string s in get_perms(so_far + ch, new_remains))
                    yield return s;
            }
        }

        private bool is_cube(long n)
        {
            double cr = Math.Round(Math.Pow(n, 1.0 / 3.0), 4);
            return cr == (int)cr;
        }
    }
}
