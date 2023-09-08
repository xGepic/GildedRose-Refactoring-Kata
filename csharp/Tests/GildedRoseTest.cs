using csharp.Tests;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
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
        [Test]
        public void TheQualityOfAnItemIsNeverNegative()
        {
            //Arrange
            GildedRose app = new GildedRose(new List<Item> { new Item { Name = "Random Item", SellIn = 0, Quality = 0 } });
            //Act
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Random Item", SellIn = -1, Quality = 0 }, app.GetItems()[0]);
        }
        [Test]
        public void SulfurasNeverChanges()
        {
            //Arrange
            GildedRose app = new GildedRose(new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 100, Quality = 100 } });
            //Act
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 100, Quality = 100 }, app.GetItems()[0]);
        }
        [Test] //Backstage passes to a TAFKAL80ETC concert
        public void BackstagePassIncreasesInQualityBy2WhenThereAre10DaysOrLess()
        {
            //Arrange
            GildedRose app = new GildedRose(new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 2 } });
            //Act
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 4 }, app.GetItems()[0]);
        }
        [Test]
        public void BackstagePassIncreasesInQualityBy3WhenThereAre5DaysOrLess()
        {
            //Arrange
            GildedRose app = new GildedRose(new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 2 } });
            //Act
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 5 }, app.GetItems()[0]);
        }
        [Test]
        public void BackstagePassIncreasesInQualityGoes0WhenSellInExpires()
        {
            //Arrange
            GildedRose app = new GildedRose(new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } });
            //Act
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 }, app.GetItems()[0]);
        }
    }
}
