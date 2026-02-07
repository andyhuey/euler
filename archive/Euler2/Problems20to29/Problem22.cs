/*
 * http://projecteuler.net/problem=22
 * Names scores
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problems20to29
{
    class Problem22
    {
        public long soln1()
        {
            string[] names_data = File.ReadAllLines(
            @"C:\Users\andrew\Documents\Visual Studio 2012\Projects\Euler\Euler2\Problems20to29\names.txt");
            List<string> names_list = new List<string>();
            foreach (string line in names_data)
            {
                string[] names_line = line.Split(',');
                //names_list.AddRange(names_line);
                foreach (string name in names_line)
                {
                    string name1 = name.Trim().Trim('"');
                    if (!string.IsNullOrEmpty(name1))
                        names_list.Add(name1);
                }
            }

            // sort the list
            names_list.Sort();

            // process the scores
            long total_score = 0;
            int pos = 0;

            foreach (string name in names_list)
            {
                int ns = NameScore(name);
                pos++;
                total_score += (ns * pos);
                //Console.WriteLine("{0}: {1}", name, ns);
            }
            return total_score;
            //Console.WriteLine("The answer is {0}", total_score);
            //Console.ReadLine();
        } // end Main

        private int NameScore(string name)
        {
            int score = 0;
            foreach (char ch in name)
            {
                score += (int)ch - (int)'A' + 1;
            }
            return score;
        }
    }
}
