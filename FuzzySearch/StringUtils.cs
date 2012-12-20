using System;

namespace FuzzySearch
{
    // NOTE: possible perf (size of memory used) improvement for tweaks - store the shorter string arr values instead of always storing the pattern arr values
    public class StringUtils
    {
        private static int Min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        public static int LevenshteinPrime(string str, string pattern)
        {
            if (string.IsNullOrEmpty(str)) return string.IsNullOrEmpty(pattern) ? 0 : pattern.Length;
            if (string.IsNullOrEmpty(pattern)) return string.IsNullOrEmpty(str) ? 0 : str.Length;

            var dist = new int[str.Length + 1, pattern.Length + 1];

            for (var i = 0; i < str.Length + 1; i++)
                dist[i, 0] = i;

            for (var j = 0; j < pattern.Length + 1; j++)
                dist[0, j] = j;

            for (var i = 1; i < str.Length + 1; i++)
                for (var j = 1; j < pattern.Length + 1; j++)
                    if (str[i - 1] == pattern[j - 1])
                        dist[i, j] = dist[i - 1, j - 1];
                    else
                        dist[i, j] = Min(dist[i - 1, j] + 1, // delete
                                         dist[i, j - 1] + 1, // add
                                         dist[i - 1, j - 1] + 1); // subst

            return dist[str.Length, pattern.Length];
        }

        public static int DamerauLevenshteinPrime(string str, string pattern)
        {
            if (string.IsNullOrEmpty(str)) return string.IsNullOrEmpty(pattern) ? 0 : pattern.Length;
            if (string.IsNullOrEmpty(pattern)) return string.IsNullOrEmpty(str) ? 0 : str.Length;

            var dist = new int[str.Length + 1, pattern.Length + 1];

            for (var i = 0; i < str.Length + 1; i++)
                dist[i, 0] = i;

            for (var j = 0; j < pattern.Length + 1; j++)
                dist[0, j] = j;

            for (var i = 1; i < str.Length + 1; i++)
                for (var j = 1; j < pattern.Length + 1; j++)
                {
                    var cost = str[i - 1] == pattern[j - 1] ? 0 : 1;

                    dist[i, j] = Min(dist[i - 1, j] + 1, // delete
                                     dist[i, j - 1] + 1, // add
                                     dist[i - 1, j - 1] + cost); // subst

                    if (i > 1 && j > 1 && str[i - 1] == pattern[j - 2] && str[i - 2] == pattern[j - 1])
                        dist[i, j] = Math.Min(dist[i, j],
                                              dist[i - 2, j - 2] + cost); // transposition
                }

            return dist[str.Length, pattern.Length];            
        }

        public static int LevenshteinTweaked(string str, string pattern)
        {
            if (string.IsNullOrEmpty(str)) return string.IsNullOrEmpty(pattern) ? 0 : pattern.Length;
            if (string.IsNullOrEmpty(pattern)) return string.IsNullOrEmpty(str) ? 0 : str.Length;

            var distJ = new int[pattern.Length + 1];
            for (var j = 0; j < pattern.Length + 1; j++)
                distJ[j] = j;

            var prev = 0;
            var prevPush = 0;
            for (var i = 1; i < str.Length + 1; i++)
            {
                prev = i;

                for (var j = 1; j < pattern.Length + 1; j++)
                {
                    if (j > 1)
                        distJ[j - 2] = prevPush;

                    prevPush = prev;

                    if (str[i - 1] == pattern[j - 1])
                        prev = distJ[j - 1];
                    else
                        prev = Min(distJ[j] + 1, // delete
                                   prev + 1, // add
                                   distJ[j - 1] + 1); // subst
                }

                distJ[distJ.Length - 2] = prevPush;
                distJ[distJ.Length - 1] = prev;
            }

            return prev;
        }

        public static int DamerauLevenshteinTweaked(string str, string pattern)
        {
            if (string.IsNullOrEmpty(str)) return string.IsNullOrEmpty(pattern) ? 0 : pattern.Length;
            if (string.IsNullOrEmpty(pattern)) return string.IsNullOrEmpty(str) ? 0 : str.Length;

            var distJ = new int[pattern.Length + 1];
            for (var j = 0; j < pattern.Length + 1; j++)
                distJ[j] = j;

            var prevDistJ = new int[distJ.Length];
            var tempDistJ = new int[distJ.Length];

            var prev = 0;
            var prevPush = 0;
            for (var i = 1; i < str.Length + 1; i++)
            {
                prev = i;
                distJ.CopyTo(tempDistJ, 0);

                for (var j = 1; j < pattern.Length + 1; j++)
                {
                    if (j > 1)
                        distJ[j - 2] = prevPush;

                    prevPush = prev;

                    var cost = str[i - 1] == pattern[j - 1] ? 0 : 1;

                    prev = Min(distJ[j] + 1, // delete
                               prev + 1, // add
                               distJ[j - 1] + cost); // subst

                    if (i > 1 && j > 1 && str[i - 1] == pattern[j - 2] && str[i - 2] == pattern[j - 1])
                        prev = Math.Min(prev, prevDistJ[j - 2] + cost); // transposition
                }

                distJ[distJ.Length - 2] = prevPush;
                distJ[distJ.Length - 1] = prev;

                tempDistJ.CopyTo(prevDistJ, 0);
            }

            return prev;
        }

        public static int LongestCommonSubsequenceLength(string str, string pattern)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(pattern)) return 0;

            var lengths = new int[str.Length + 1, pattern.Length + 1];

            for (var i = 1; i < str.Length + 1; i++)
            {
                for (var j = 1; j < pattern.Length + 1; j++)
                {
                    if (str[i - 1] == pattern[j - 1])
                        lengths[i, j] = lengths[i - 1, j - 1] + 1;
                    else
                        lengths[i, j] = Math.Max(lengths[i, j - 1], lengths[i - 1, j]);
                }
            }

            return lengths[str.Length, pattern.Length];            
        }

        public static int LongestCommonSubsequenceLengthTweaked(string str, string pattern)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(pattern)) return 0;

            var lengths = new int[pattern.Length + 1];
            var prev = 0;
            var prevPush = 0;

            for (var i = 1; i < str.Length + 1; i++)
            {
                prev = 0;

                for (var j = 1; j < pattern.Length + 1; j++)
                {
                    if (j > 1)
                        lengths[j - 2] = prevPush;

                    prevPush = prev;

                    if (str[i - 1] == pattern[j - 1])
                        prev = lengths[j - 1] + 1;
                    else
                        prev = Math.Max(prev, lengths[j]);
                }

                lengths[lengths.Length - 2] = prevPush;
                lengths[lengths.Length - 1] = prev;
            }

            return prev;
        }

        // lower memory usage than tweaked version but a bit slower according to tests
        public static int LongestCommonSubsequenceLengthReTweaked(string str, string pattern)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(pattern)) return 0;
            if (str.Length < pattern.Length)
            {
                var temp = str;
                str = pattern;
                pattern = temp;
            }

            var lengths = new int[pattern.Length + 1];
            var prev = 0;
            var prevPush = 0;

            for (var i = 1; i < str.Length + 1; i++)
            {
                prev = 0;

                for (var j = 1; j < pattern.Length + 1; j++)
                {
                    if (j > 1)
                        lengths[j - 2] = prevPush;

                    prevPush = prev;

                    if (str[i - 1] == pattern[j - 1])
                        prev = lengths[j - 1] + 1;
                    else
                        prev = Math.Max(prev, lengths[j]);
                }

                lengths[lengths.Length - 2] = prevPush;
                lengths[lengths.Length - 1] = prev;
            }

            return prev;
        }
    }
}