using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    public class ConjuredItemTests
    {
        [Test]
        public void ConjuredItemDecreasesInQualityTwicAsFast()
        {
            //Arrange
            GildedRose app = new GildedRose(new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 5 } });
            //Act 
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = 3 }, app.GetItems()[0]);
        }
        [Test]
        public void ConjuredItemDecreasesInQualityTwicAsFastAlsoWhenSellInIsExpired()
        {
            //Arrange
            GildedRose app = new GildedRose(new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 5 } });
            //Act 
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 1 }, app.GetItems()[0]);
        }
    }
}
