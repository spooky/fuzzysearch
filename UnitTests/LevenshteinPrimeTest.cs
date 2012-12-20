using FuzzySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class LevenshteinPrimeTest
    {
        [TestMethod]
        public void TestNulls()
        {
            Assert.AreEqual(0, StringUtils.LevenshteinPrime(null, null));
            Assert.AreEqual(0, StringUtils.LevenshteinPrime("", null));
            Assert.AreEqual(0, StringUtils.LevenshteinPrime(null, ""));
            Assert.AreEqual(3, StringUtils.LevenshteinPrime(null, "abc"));
            Assert.AreEqual(3, StringUtils.LevenshteinPrime("abc", null));
        }

        [TestMethod]
        public void TestLevenshteinPrime()
        {
            Assert.AreEqual(0, StringUtils.LevenshteinPrime("test", "test"));
            Assert.AreEqual(1, StringUtils.LevenshteinPrime("granat", "granit"));
            Assert.AreEqual(3, StringUtils.LevenshteinPrime("orczyk", "oracz"));
            Assert.AreEqual(4, StringUtils.LevenshteinPrime("marka", "ariada"));
        }
    }
}