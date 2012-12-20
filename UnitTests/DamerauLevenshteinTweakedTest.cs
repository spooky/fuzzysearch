using FuzzySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DamerauLevenshteinTweakedTest
    {
        [TestMethod]
        public void TestNulls()
        {
            Assert.AreEqual(0, StringUtils.DamerauLevenshteinTweaked(null, null));
            Assert.AreEqual(0, StringUtils.DamerauLevenshteinTweaked("", null));
            Assert.AreEqual(0, StringUtils.DamerauLevenshteinTweaked(null, ""));
            Assert.AreEqual(3, StringUtils.DamerauLevenshteinTweaked(null, "abc"));
            Assert.AreEqual(3, StringUtils.DamerauLevenshteinTweaked("abc", null));
        }

        [TestMethod]
        public void TestDamerauLevenshteinTweaked()
        {
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("test", "tset"));
            Assert.AreEqual(0, StringUtils.DamerauLevenshteinTweaked("test", "test"));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("granat", "granit"));
            Assert.AreEqual(3, StringUtils.DamerauLevenshteinTweaked("orczyk", "oracz"));
            Assert.AreEqual(4, StringUtils.DamerauLevenshteinTweaked("marka", "ariada"));
        }

        [TestMethod]
        public void TestTranspositions()
        {
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("test", "tset"));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("ab", "ba"));
            Assert.AreEqual(0, StringUtils.DamerauLevenshteinTweaked("ab", "ab"));
            Assert.AreEqual(3, StringUtils.DamerauLevenshteinTweaked("acde", "abdcg"));
        }

        [TestMethod]
        public void TestOnEmptyStrings()
        {
            Assert.AreEqual(0, StringUtils.DamerauLevenshteinTweaked("", ""));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("a", ""));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("", "a"));
            Assert.AreEqual(3, StringUtils.DamerauLevenshteinTweaked("abc", ""));
            Assert.AreEqual(3, StringUtils.DamerauLevenshteinTweaked("", "abc"));
        }

        [TestMethod]
        public void TestOnEqualStrings()
        {
            Assert.AreEqual(0, StringUtils.DamerauLevenshteinTweaked("", ""));
            Assert.AreEqual(0, StringUtils.DamerauLevenshteinTweaked("a", "a"));
            Assert.AreEqual(0, StringUtils.DamerauLevenshteinTweaked("abc", "abc"));
        }

        [TestMethod]
        public void TestWhereOnlyInsertsAreNeeded()
        {
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("", "a"));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("a", "ab"));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("b", "ab"));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("ac", "abc"));
            Assert.AreEqual(6, StringUtils.DamerauLevenshteinTweaked("abcdefg", "xabxcdxxefxgx"));
        }

        [TestMethod]
        public void TestWhereOnlyDeletesAreNeeded()
        {
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("a", ""));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("ab", "a"));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("ab", "b"));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("abc", "ac"));
            Assert.AreEqual(6, StringUtils.DamerauLevenshteinTweaked("xabxcdxxefxgx", "abcdefg"));
        }

        [TestMethod]
        public void TestWhereOnlySubstitutionsAreNeeded()
        {
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("a", "b"));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("ab", "ac"));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("ac", "bc"));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinTweaked("abc", "axc"));
            Assert.AreEqual(6, StringUtils.DamerauLevenshteinTweaked("xabxcdxxefxgx", "1ab2cd34ef5g6"));
        }

        [TestMethod]
        public void TestWhereManyOperationsAreNeeded()
        {
            Assert.AreEqual(3, StringUtils.DamerauLevenshteinTweaked("example", "samples"));
            Assert.AreEqual(6, StringUtils.DamerauLevenshteinTweaked("sturgeon", "urgently"));
            Assert.AreEqual(6, StringUtils.DamerauLevenshteinTweaked("levenshtein", "frankenstein"));
            Assert.AreEqual(5, StringUtils.DamerauLevenshteinTweaked("distance", "difference"));
            Assert.AreEqual(7, StringUtils.DamerauLevenshteinTweaked("java was neat", "scala is great"));
        }
    }
}