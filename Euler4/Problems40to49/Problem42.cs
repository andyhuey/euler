/*
 * http://projecteuler.net/problem=42
 * Coded triangle numbers
 * Answer: 162
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems40to49
{
    class Problem42
    {
        List<string> word_list;
        List<int> triangle_nums;

        public long soln1()
        {
            int ans = 0;
            var sw = Stopwatch.StartNew();

            // read the input file.
            readFile();
            Console.WriteLine("{0} words read.", word_list.Count);

            // seed the first few.
            triangle_nums = new List<int>();
            for (int i = 0; i < 4; i++)
                triangle_nums.Add(triangleNum(i));

            //Console.WriteLine(isTriangleNum(55));
            //Console.WriteLine(isTriangleNum(100));
            //Console.WriteLine("score for SKY is {0}", wordScore("SKY"));
            //Console.WriteLine("t(10) is {0}", triangleNum(10));

            foreach (var word in word_list)
            {
                if (isTriangleNum(wordScore(word)))
                {
                    ans++;
                    Console.WriteLine("{0} -> {1}", word, wordScore(word));
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} sec", sw.Elapsed.Seconds);
            return ans;
        }

        private void readFile()
        {
            string[] words_data = File.ReadAllLines(
            @"C:\Users\ahuey\Documents\Visual Studio 2012\Projects\Euler\Euler4\Problems40to49\p042_words.txt");
            this.word_list = new List<string>();
            foreach (string line in words_data)
            {
                string[] word_line = line.Split(',');
                foreach (string word in word_line)
                {
                    string word1 = word.Trim().Trim('"');
                    if (!string.IsNullOrEmpty(word1))
                        word_list.Add(word1);
                }
            }
        }

        private int wordScore(string word)
        {
            // assume input is upper-case string.
            // A=1, B=2...
            int score = 0;
            foreach (char ch in word)
            {
                score += (int)ch - (int)'A' + 1;
            }
            return score;
        }

        private int triangleNum(int n)
        {
            return n * (n + 1) / 2;
        }

        private bool isTriangleNum(int n)
        {
            // do we have it in the list yet?
            while (n > triangle_nums.Max())
            {
                int i = triangle_nums.Count;
                triangle_nums.Add(triangleNum(i));
            }
            // now we do.
            if (triangle_nums.Any(x => x == n))
                return true;
            return false;
        }

    }
}
