using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    public class SulfurasTests
    {
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
    }
}
