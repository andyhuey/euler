﻿/*
 * http://projecteuler.net/problem=14
 * Longest Collatz sequence
 * NOTE: the previous solution, with the array, is better than this one...
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problems11to19
{
    class Problem14
    {
        const int max_n = 1000000;
        Dictionary<long,long> cslen;

        public long soln1()
        {
            //int loopIterations = 0;
            var sw = Stopwatch.StartNew();

            // this array will track the # of elements in the Collatz seq for input N
            cslen = new Dictionary<long, long>();

            long maxIndex = 0, maxValue = 0;
            for (int i = 1; i < max_n; i++)
            {
                cslen[i] = getCollatzSeqLen(i);
                //Console.WriteLine("{0}: {1}", i, cslen[i]);
                if (cslen[i] > maxValue)
                {
                    maxIndex = i;
                    maxValue = cslen[i];
                }
            }

            sw.Stop();
            Console.WriteLine("elapsed: {0} ms", sw.Elapsed.TotalMilliseconds);
            //Console.WriteLine("Loop iterations: {0:n0}", loopIterations);
            Console.WriteLine("seq for {0} is {1} long.", maxIndex, maxValue);
            return maxIndex;
        }

        long getCollatzSeqLen(long n)
        {
            long seqlen = 0;
            if (n == 1)
                return 1;
            while (n > 1)
            {
                if (cslen.ContainsKey(n))
                {
                    return seqlen + cslen[n];
                }
                seqlen++;
                n = nextCollatzNum(n);
                //Console.Write("{0}, ", n);
            }
            seqlen++;
            return seqlen;
        }

        long nextCollatzNum(long n)
        {
            if (n == 1)
                return n;
            if (n % 2 == 0)
                return n / 2;
            else
                return (n * 3) + 1;
        }
    }
}
