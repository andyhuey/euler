/*
 * https://projecteuler.net/problem=62
 * Cubic permutations
 * Find the smallest cube for which exactly five permutations of its digits are cube.
 * 404: 65939264,65939246,69934526,69426539,26463599 - nope.
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
            long rv = 0;
            var sw = Stopwatch.StartNew();

            // this is somewhat brain-dead, but let's just step through cubes, and see if we hit the right one...
            long n = 300;
            long n_cube = n * n * n;
            while (n_cube < Int32.MaxValue)
            {
                var my_perms = this.get_permutations(n_cube.ToString())
                    .Where(x => Int64.Parse(x) >= n_cube);
                var cubes = my_perms.Where(x => is_cube(Int64.Parse(x)));
                if (cubes.Count() >= 3)
                {
                    Console.WriteLine("{0}: {1}", n, string.Join(",", cubes));
                }
                if (cubes.Count() == 5)
                {
                    rv = n_cube;
                    break;
                }
                n++;
                n_cube = n * n * n;
                if (n % 100 == 0)
                    Console.WriteLine("[at n={0}]", n);
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return rv;
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
            double cr = Math.Round(Math.Pow(n, 1.0 / 3.0), 8);
            return cr == (int)cr;
        }
    }
}
