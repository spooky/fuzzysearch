namespace FuzzySearch
{
    public static class StringExtensions
    {
        public static int LevenshteinDistance(this string str, string pattern)
        {
            return StringUtils.LevenshteinTweaked(str, pattern);
        }

        public static int DamerauLevenshteinDistance(this string str, string pattern)
        {
            return StringUtils.DamerauLevenshteinTweaked(str, pattern);
        }

        public static int LCSLength(this string str, string pattern)
        {
            return StringUtils.LongestCommonSubsequenceLengthTweaked(str, pattern);
        }
    }
}