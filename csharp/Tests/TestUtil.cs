using NUnit.Framework;

namespace csharp.Tests
{
    public static class TestUtil
    {
        public static void CustomItemAssertEquals(Item expected, Item actual)
        {
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.SellIn, actual.SellIn);
            Assert.AreEqual(expected.Quality, actual.Quality);
        }
    }
}
