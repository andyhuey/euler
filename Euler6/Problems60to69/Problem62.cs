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
        Dictionary<int, long> cubes;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            
            cubes = new Dictionary<int, long>();
            cubes.Add(1, 1);    // 1^3 -> 1
            cubes.Add(2, 2 * 2 * 2);

            //Console.WriteLine(is_cube(27));
            //Console.WriteLine(is_cube(60));

            var my_perms = this.get_permutations("", "41063625");
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

        private IEnumerable<string> get_permutations(string so_far, string remains)
        {
            // this should return all the permutations of a string, without worrying about uniqueness.
            if (remains == "")
                yield return so_far;
            for (int i = 0; i < remains.Length; i++)
            {
                char ch = remains[i];
                string new_remains = remains.Remove(i, 1);
                foreach (string s in get_permutations(so_far + ch, new_remains))
                    yield return s;
            }
        }

        private bool is_cube(long n)
        {
            //double cr = Math.Pow(n, 1.0 / 3.0);
            //return cr == (int)cr;
            if (cubes.Where((k, v) => v == n).Any())
                return true;
            if (n < cubes.Select((k,v) => v).Max())
                return false;
            int k1 = cubes.Select((k,v) => k).Max());

        }
    }
}
