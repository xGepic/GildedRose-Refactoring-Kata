using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    public class BackstagePassTests
    {
        [Test]
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
