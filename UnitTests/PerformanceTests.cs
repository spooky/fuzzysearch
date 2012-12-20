using System;
using System.Diagnostics;
using FuzzySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class PerformanceTests
    {
        private Stopwatch stopwatch = new Stopwatch();

        [TestMethod]
        public void LevenshteinPrimeVsLevenshteinTweaked()
        {
            const int numIterations = 100000;

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < numIterations; i++)
            {
                StringUtils.LevenshteinPrime("marka", "ariada");
            }
            stopwatch.Stop();
            var primeTime = stopwatch.Elapsed;
            Console.WriteLine("Prime: " + primeTime);

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < numIterations; i++)
            {
                StringUtils.LevenshteinTweaked("marka", "ariada");
            }
            stopwatch.Stop();
            var tweakedTime = stopwatch.Elapsed;
            Console.WriteLine("Tweaked: " + tweakedTime);

            Console.WriteLine("Diff: " + (primeTime - tweakedTime));
        }

        [TestMethod]
        public void DamerauLevenshteinPrimeVsDamerauLevenshteinTweaked()
        {
            const int numIterations = 100000;

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < numIterations; i++)
            {
                StringUtils.DamerauLevenshteinPrime("marka", "ariada");
            }
            stopwatch.Stop();
            var primeTime = stopwatch.Elapsed;
            Console.WriteLine("Prime: " + primeTime);

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < numIterations; i++)
            {
                StringUtils.DamerauLevenshteinTweaked("marka", "ariada");
            }
            stopwatch.Stop();
            var tweakedTime = stopwatch.Elapsed;
            Console.WriteLine("Tweaked: " + tweakedTime);

            Console.WriteLine("Diff: " + (primeTime - tweakedTime));
        }

        [TestMethod]
        public void LevenshteinTweakedVsDamerauLevenshteinTweaked()
        {
            const int numIterations = 100000;

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < numIterations; i++)
            {
                StringUtils.LevenshteinTweaked("marka", "ariada");
            }
            stopwatch.Stop();
            var primeTime = stopwatch.Elapsed;
            Console.WriteLine("LevenshteinTweaked: " + primeTime);

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < numIterations; i++)
            {
                StringUtils.DamerauLevenshteinTweaked("marka", "ariada");
            }
            stopwatch.Stop();
            var tweakedTime = stopwatch.Elapsed;
            Console.WriteLine("DamerauLevenshteinTweaked: " + tweakedTime);

            Console.WriteLine("Diff: " + (primeTime - tweakedTime));
        }

        [TestMethod]
        public void LCSvsLCSTweaked()
        {
            const int numIterations = 100000;

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < numIterations; i++)
            {
                StringUtils.LongestCommonSubsequenceLength("marka", "ariada");
            }
            stopwatch.Stop();
            var primeTime = stopwatch.Elapsed;
            Console.WriteLine("LCS: " + primeTime);

            stopwatch.Reset();
            stopwatch.Start();
            for (var i = 0; i < numIterations; i++)
            {
                StringUtils.LongestCommonSubsequenceLengthTweaked("marka", "ariada");
            }
            stopwatch.Stop();
            var tweakedTime = stopwatch.Elapsed;
            Console.WriteLine("LCSTweaked: " + tweakedTime);

            Console.WriteLine("Diff: " + (primeTime - tweakedTime));
        } 
    }
}