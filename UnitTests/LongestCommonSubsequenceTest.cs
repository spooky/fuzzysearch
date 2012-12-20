using FuzzySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class LongestCommonSubsequenceTest
    {
        [TestMethod]
        public void TestLongestCommonSubsequenceLength()
        {
            Assert.AreEqual(3, StringUtils.LongestCommonSubsequenceLength("abc", "abc"));
            Assert.AreEqual(0, StringUtils.LongestCommonSubsequenceLength("", "abc"));
            Assert.AreEqual(0, StringUtils.LongestCommonSubsequenceLength(null, "abc"));
            Assert.AreEqual(0, StringUtils.LongestCommonSubsequenceLength("abc", ""));
            Assert.AreEqual(0, StringUtils.LongestCommonSubsequenceLength("abc", null));
            Assert.AreEqual(1, StringUtils.LongestCommonSubsequenceLength("abc", "a"));
            Assert.AreEqual(1, StringUtils.LongestCommonSubsequenceLength("abc", "b"));
            Assert.AreEqual(1, StringUtils.LongestCommonSubsequenceLength("abc", "c"));
            Assert.AreEqual(2, StringUtils.LongestCommonSubsequenceLength("abc", "ac"));
            Assert.AreEqual(2, StringUtils.LongestCommonSubsequenceLength("abc", "ab"));
            Assert.AreEqual(2, StringUtils.LongestCommonSubsequenceLength("abc", "bc"));
            Assert.AreEqual(1, StringUtils.LongestCommonSubsequenceLength("abc", "ba"));
        }
    }
}