using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    internal class ItemTests
    {
        [Test]
        public void TheQualityOfAnItemIsNeverNegative()
        {
            //Arrange
            NewGildedRose app = new NewGildedRose(new List<Item> { new Item { Name = "Random Item", SellIn = 0, Quality = 0 } });
            //Act
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Random Item", SellIn = -1, Quality = 0 }, app.GetItems()[0]);
        }
    }
}
