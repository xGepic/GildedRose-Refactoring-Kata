using csharp.Tests;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class AgedBrieTests
    {
        [Test]
        public void AgedBrieSellInAndQualityDecrease()
        {
            //Arrange
            GildedRose app = new GildedRose(new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 2 } });
            //Act 
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Aged Brie", SellIn = 1, Quality = 3 }, app.GetItems()[0]);
        }
        [Test]
        public void AgedBrieSellByDatePassedAndQualityDecreasesTwice()
        {
            //Arrange
            GildedRose app = new GildedRose(new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 4 } });
            //Act
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Aged Brie", SellIn = -1, Quality = 0 }, app.GetItems()[0]);
        }
        [Test]
        public void AgedBrieQualityIsNeverOver50()
        {
            //Arrange
            GildedRose app = new GildedRose(new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } });
            //Act
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 }, app.GetItems()[0]);
        }
    }
}
