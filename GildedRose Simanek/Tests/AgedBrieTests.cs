﻿using csharp.Tests;
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
            NewGildedRose app = new NewGildedRose(new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 2 } });
            //Act 
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Aged Brie", SellIn = 1, Quality = 3 }, app.GetItems()[0]);
        }
        [Test]
        public void AgedBrieSellByDatePassedAndQualityDecreasesTwice()
        {
            //Arrange
            NewGildedRose app = new NewGildedRose(new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 2 } });
            //Act
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Aged Brie", SellIn = -1, Quality = 4 }, app.GetItems()[0]);
        }
        [Test]
        public void AgedBrieQualityIsNeverOver50()
        {
            //Arrange
            NewGildedRose app = new NewGildedRose(new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } });
            //Act
            app.UpdateQuality();
            //Assert
            TestUtil.CustomItemAssertEquals(new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 }, app.GetItems()[0]);
        }
    }
}
