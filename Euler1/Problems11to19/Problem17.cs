/*
 * http://projecteuler.net/problem=17
 * If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, 
 * how many letters would be used? 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Numerics;

namespace Problems11to19
{
    class Problem17
    {
        const int max_n = 1000;

        public long soln1()
        {
            var sw = Stopwatch.StartNew();
            long nLettersTotal = 0;

            for (int i = 1; i <= max_n; i++)
            {
                nLettersTotal += count_letters(spell_number(i));
                //Console.WriteLine("{0}: {1}", i, spell_number(i));
                //if (i % 20 == 0)
                //{
                //    Console.WriteLine("Press enter to continue...");
                //    Console.ReadLine();
                //}
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);

            return nLettersTotal;
        }

        private int count_letters(string s)
        {
            // count the letters in a string
            int n = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsLetter(s[i]))
                    n++;
            }
            return n;
        }

        private string[] first19 = 
        {
            "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
            "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
            "eighteen", "nineteen"
        };

        private string[] tens = 
        {
            "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
        };

        string spell_number(int n)
        {
            if (n > max_n)
                throw new ArgumentOutOfRangeException(
                    string.Format("value of n={0}, max is {1}.", n, max_n));
            if (n < 1)
                throw new ArgumentOutOfRangeException(
                    string.Format("value of n={0}, min is {1}.", n, 1));
            
            StringBuilder sb = new StringBuilder();
            bool bHasHundreds = false;
            bool bhasTeens = false;

            if (n == 1000)
                return "one thousand";
            if (n >= 100)
            {
                sb.AppendFormat("{0} hundred", first19[n / 100]);
                n = n % 100;
                bHasHundreds = true;
            }
            if (n >= 20)
            {
                if (bHasHundreds)
                    sb.Append(" and ");
                sb.Append(tens[n / 10]);
                n = n % 10;
                bhasTeens = true;
            }
            if (n > 0)
            {
                if (bHasHundreds && !bhasTeens)
                    sb.AppendFormat(" and ");
                if (bhasTeens)
                    sb.Append("-");
                sb.Append(first19[n]);
            }

            return sb.ToString();
        }
    }
}

