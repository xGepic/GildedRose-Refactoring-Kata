using csharp.Tests;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void EndOfDaySellInAndQualityDecrease()
        {
            //Arrange
            GildedRose app = new GildedRose(new List<Item> { new Item { Name = "Aged Item", SellIn = 2, Quality = 2 } });
            //Act 
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Aged Item", SellIn = 1, Quality = 1 }, app.GetItems()[0]);
        }
        [Test]
        public void SellByDatePassedAndQualityDecreasesTwice()
        {
            //Arrange
            GildedRose app = new GildedRose(new List<Item> { new Item { Name = "Aged Item", SellIn = 0, Quality = 2 } });
            //Act
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Aged Item", SellIn = -1, Quality = 0 }, app.GetItems()[0]);
        }
    }
}
