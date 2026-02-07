/*
 * https://projecteuler.net/problem=62
 * Cubic permutations
 * Find the largest cube for which exactly five permutations of its digits are cube.
 * 127035954683,352045367981,373559126408,569310543872,589323567104
 * The answer is 127,035,954,683 or 127035954683
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
        // key is the largest perm (not necessarily a cube itself). 
        // value is a list of all perms that are cubes.
        Dictionary<long, List<long>> myCubePerms;

        public long soln1()
        {
            long rv = 0;
            var sw = Stopwatch.StartNew();

            myCubePerms = new Dictionary<long, List<long>>();

            // step through cubes & build up our list until we get an entry with 5 cubes.
            long n = 300;
            long n_cube = n * n * n;
            while (n_cube < Int64.MaxValue)
            {
                long largest_perm = Convert.ToInt64(get_largest_perm(n_cube.ToString()));
                if (myCubePerms.ContainsKey(largest_perm))
                {
                    var myPermList = myCubePerms[largest_perm];
                    myPermList.Add(n_cube);
                    if (myPermList.Count() == 5)
                    {
                        Console.WriteLine(string.Join(",", myPermList));
                        rv = myPermList.Min();
                        break;
                    }
                }
                else
                {
                    myCubePerms.Add(largest_perm, new List<long>() { n_cube });
                }

                // next.
                n++;
                n_cube = n * n * n;
                if (n % 100 == 0)
                    Console.WriteLine("[at n={0}, n^3={1:n0}]", n, n_cube);
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return rv;
        }

        private string get_largest_perm(string s)
        {
            var ca = s.ToCharArray();
            Array.Sort(ca);
            Array.Reverse(ca);
            return new string(ca);
        }

    }
}
