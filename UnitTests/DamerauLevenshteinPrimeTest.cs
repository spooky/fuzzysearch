using FuzzySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DamerauLevenshteinPrimeTest
    {
        [TestMethod]
        public void TestNulls()
        {
            Assert.AreEqual(0, StringUtils.DamerauLevenshteinPrime(null, null));
            Assert.AreEqual(0, StringUtils.DamerauLevenshteinPrime("", null));
            Assert.AreEqual(0, StringUtils.DamerauLevenshteinPrime(null, ""));
            Assert.AreEqual(3, StringUtils.DamerauLevenshteinPrime(null, "abc"));
            Assert.AreEqual(3, StringUtils.DamerauLevenshteinPrime("abc", null));
        }

        [TestMethod]
        public void TestDamerauLevenshteinPrime()
        {
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinPrime("test", "tset"));
            Assert.AreEqual(0, StringUtils.DamerauLevenshteinPrime("test", "test"));
            Assert.AreEqual(1, StringUtils.DamerauLevenshteinPrime("granat", "granit"));
            Assert.AreEqual(3, StringUtils.DamerauLevenshteinPrime("orczyk", "oracz"));
            Assert.AreEqual(4, StringUtils.DamerauLevenshteinPrime("marka", "ariada"));
        }
    }
}