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

            //int[] thePassword = new int[] {(int)'g', (int)'o', (int)'d'};
            //return getDecryptSum(thePassword, inputData);

            var possPws = getAllPasswords();
            Console.WriteLine("Generated {0} possible passwords.", possPws.Count());

            int nspacesMax = 0;
            int[] hldpw = new int[3];

            foreach (var pw in possPws)
            {
                int nspaces;
                if (isPossiblePw(pw, inputData, out nspaces))
                {
                    possiblePws++;
                    if (nspaces > nspacesMax)
                    {
                        nspacesMax = nspaces;
                        hldpw = pw;
                    }
                    //printDecrypt(pw, inputData);
                    //if (possiblePws % 20 == 0)
                    //    Console.ReadLine();
                }
            }
            Console.WriteLine("possible passwords: {0}", possiblePws);

            Console.WriteLine("Password is probably: {0}", new string(hldpw.Select(x => (char)x).ToArray()));
            int sum = getDecryptSum(hldpw, inputData);

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            return sum;
        }

        private IEnumerable<int> getInputData()
        {
            int i;
            string inputText = File.ReadAllText(
            @"C:\Users\ahuey\Documents\Visual Studio 2012\Projects\Euler\Euler5\Problems50to59\p059_cipher.txt");
            foreach (string s in inputText.Split(','))
            {
                if (int.TryParse(s, out i))
                    yield return i;
            }
        }

        private IEnumerable<int[]> getAllPasswords()
        {
            IEnumerable<int> lcLtrs = Enumerable.Range((int)'a', 26);
            foreach (int c1 in lcLtrs)
                foreach (int c2 in lcLtrs)
                    foreach (int c3 in lcLtrs)
                        yield return new int[] { c1, c2, c3 };
        }

        private bool isPossiblePw(int[] pw, IEnumerable<int> inputData, out int nspaces)
        {
            nspaces = 0;
            int i = 0;
            int x2;
            foreach (int x1 in inputData)
            {
                x2 = x1 ^ pw[i];
                if (x2 < 32 || x2 > 126)
                    return false;   // not a printable char
                if (x2 == 32)
                    nspaces++;      // count the spaces
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
            //sumChars = sb.ToString().Sum(c => (int)c);
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
