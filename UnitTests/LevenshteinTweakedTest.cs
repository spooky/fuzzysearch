using FuzzySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class LevenshteinTweakedTest
    {
        [TestMethod]
        public void TestNulls()
        {
            Assert.AreEqual(0, StringUtils.LevenshteinTweaked(null, null));
            Assert.AreEqual(0, StringUtils.LevenshteinTweaked("", null));
            Assert.AreEqual(0, StringUtils.LevenshteinTweaked(null, ""));
            Assert.AreEqual(3, StringUtils.LevenshteinTweaked(null, "abc"));
            Assert.AreEqual(3, StringUtils.LevenshteinTweaked("abc", null));
        }

        [TestMethod]
        public void TestOnEmptyStrings()
        {
            Assert.AreEqual(0, StringUtils.LevenshteinTweaked("", ""));
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("a", ""));
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("", "a"));
            Assert.AreEqual(3, StringUtils.LevenshteinTweaked("abc", ""));
            Assert.AreEqual(3, StringUtils.LevenshteinTweaked("", "abc"));
        }

        [TestMethod]
        public void TestOnEqualStrings()
        {
            Assert.AreEqual(0, StringUtils.LevenshteinTweaked("", ""));
            Assert.AreEqual(0, StringUtils.LevenshteinTweaked("a", "a"));
            Assert.AreEqual(0, StringUtils.LevenshteinTweaked("abc", "abc"));
        }

        [TestMethod]
        public void TestWhereOnlyInsertsAreNeeded()
        {
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("", "a"));
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("a", "ab"));
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("b", "ab"));
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("ac", "abc"));
            Assert.AreEqual(6, StringUtils.LevenshteinTweaked("abcdefg", "xabxcdxxefxgx"));
        }

        [TestMethod]
        public void TestWhereOnlyDeletesAreNeeded()
        {
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("a", ""));
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("ab", "a"));
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("ab", "b"));
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("abc", "ac"));
            Assert.AreEqual(6, StringUtils.LevenshteinTweaked("xabxcdxxefxgx", "abcdefg"));
        }

        [TestMethod]
        public void TestWhereOnlySubstitutionsAreNeeded()
        {
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("a", "b"));
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("ab", "ac"));
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("ac", "bc"));
            Assert.AreEqual(1, StringUtils.LevenshteinTweaked("abc", "axc"));
            Assert.AreEqual(6, StringUtils.LevenshteinTweaked("xabxcdxxefxgx", "1ab2cd34ef5g6"));
        }

        [TestMethod]
        public void TestWhereManyOperationsAreNeeded()
        {
            Assert.AreEqual(3, StringUtils.LevenshteinTweaked("example", "samples"));
            Assert.AreEqual(6, StringUtils.LevenshteinTweaked("sturgeon", "urgently"));
            Assert.AreEqual(6, StringUtils.LevenshteinTweaked("levenshtein", "frankenstein"));
            Assert.AreEqual(5, StringUtils.LevenshteinTweaked("distance", "difference"));
            Assert.AreEqual(7, StringUtils.LevenshteinTweaked("java was neat", "scala is great"));
        }
    }
}
