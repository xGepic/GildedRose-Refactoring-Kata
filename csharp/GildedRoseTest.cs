using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        public static void CustomItemAssertEquals(Item expected, Item actual)
        {
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.SellIn, actual.SellIn);
            Assert.AreEqual(expected.Name, actual.Name);
        }
        [Test]
        public void EndOfDaySellInAndQualityDecrease()
        {
            //Arrange
            GildedRose app = new GildedRose(new List<Item> { new Item { Name = "Aged Item", SellIn = 2, Quality = 2 } });
            //Act 
            app.UpdateQuality();
            //Assert
            CustomItemAssertEquals(new Item { Name = "Aged Item", SellIn = 1, Quality = 1 }, app.GetItems()[0]);
        }
    }
}
