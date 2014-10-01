/*
 * https://projecteuler.net/problem=59
 * XOR encryption
 * password is 'god'
 * The answer is 107359
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems50to59
{
    class Problem59
    {
        public long soln1()
        {
            int possiblePws = 0;
            var sw = Stopwatch.StartNew();

            var inputData = getInputData();
            Console.WriteLine("Read {0} values.", inputData.Count());

            int[] thePassword = new int[] {(int)'g', (int)'o', (int)'d'};
            return getDecryptSum(thePassword, inputData);

            var possPws = getAllPasswords();
            Console.WriteLine("Generated {0} possible passwords.", possPws.Count());

            foreach (var pw in possPws)
            {
                if (isPossiblePw(pw, inputData))
                {
                    possiblePws++;
                    printDecrypt(pw, inputData);
                    if (possiblePws % 20 == 0)
                        Console.ReadLine();
                }
            }
            Console.WriteLine("possible passwords: {0}", possiblePws);

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return 0;
        }

        private IEnumerable<int> getInputData()
        {
            int i;
            string[] inpLines = File.ReadAllLines(
            @"C:\Users\ahuey\Documents\Visual Studio 2012\Projects\Euler\Euler5\Problems50to59\p059_cipher.txt");
            foreach (string line in inpLines)
            {
                foreach (string s in line.Split(','))
                {
                    if (int.TryParse(s, out i))
                        yield return i;
                }
            }
        }

        private IEnumerable<int[]> getAllPasswords()
        {
            IEnumerable<char> lcLtrs = Enumerable.Range((int)'a', 26).Select(x => (char)x);
            //Console.WriteLine("{0} letters from {1} to {2}!", lcLtrs.Count(), (int)'a', (int)'z');
            foreach (char c1 in lcLtrs)
                foreach (char c2 in lcLtrs)
                    foreach (char c3 in lcLtrs)
                        yield return new int[] { c1, c2, c3 };
        }

        private bool isPossiblePw(int[] pw, IEnumerable<int> inputData)
        {
            int i = 0;
            int x2;
            foreach (int x1 in inputData)
            {
                x2 = x1 ^ pw[i];
                if (x2 < 32 || x2 > 126)
                    return false;   // not a printable char
                i = (i + 1) % 3;
            }
            return true;
        }

        private int getDecryptSum(int[] pw, IEnumerable<int> inputData)
        {
            int i = 0;
            int x2;
            int sumChars = 0;
            StringBuilder sb = new StringBuilder();

            foreach (int x1 in inputData)
            {
                x2 = x1 ^ pw[i];
                sb.Append((char)x2);
                sumChars += x2;
                i = (i + 1) % 3;
            }
            string spw = new string(pw.Select(x => (char)x).ToArray());
            Console.WriteLine("pw: {0} / output: {1}", spw, sb.ToString());
            return sumChars;
        }

        private void printDecrypt(int[] pw, IEnumerable<int> inputData)
        {
            int i = 0;
            int x2;
            StringBuilder sb = new StringBuilder();

            foreach (int x1 in inputData)
            {
                x2 = x1 ^ pw[i];
                sb.Append((char)x2);
                i = (i + 1) % 3;
            }

            string spw = new string(pw.Select(x => (char)x).ToArray());
            Console.WriteLine("pw: {0} / output: {1}", spw, sb.ToString().Substring(0, 40));
        }
    }
}
