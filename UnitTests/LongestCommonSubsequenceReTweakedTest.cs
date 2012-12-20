using FuzzySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class LongestCommonSubsequenceReTweakedTest
    {
        [TestMethod]
        public void TestLongestCommonSubsequenceLength()
        {
            Assert.AreEqual(3, StringUtils.LongestCommonSubsequenceLengthTweaked("abc", "abc"));
            Assert.AreEqual(0, StringUtils.LongestCommonSubsequenceLengthTweaked("", "abc"));
            Assert.AreEqual(0, StringUtils.LongestCommonSubsequenceLengthTweaked(null, "abc"));
            Assert.AreEqual(0, StringUtils.LongestCommonSubsequenceLengthTweaked("abc", ""));
            Assert.AreEqual(0, StringUtils.LongestCommonSubsequenceLengthTweaked("abc", null));
            Assert.AreEqual(1, StringUtils.LongestCommonSubsequenceLengthTweaked("abc", "a"));
            Assert.AreEqual(1, StringUtils.LongestCommonSubsequenceLengthTweaked("abc", "b"));
            Assert.AreEqual(1, StringUtils.LongestCommonSubsequenceLengthTweaked("abc", "c"));
            Assert.AreEqual(2, StringUtils.LongestCommonSubsequenceLengthTweaked("abc", "ac"));
            Assert.AreEqual(2, StringUtils.LongestCommonSubsequenceLengthTweaked("abc", "ab"));
            Assert.AreEqual(2, StringUtils.LongestCommonSubsequenceLengthTweaked("abc", "bc"));
            Assert.AreEqual(1, StringUtils.LongestCommonSubsequenceLengthTweaked("abc", "ba"));
        } 
    }
}