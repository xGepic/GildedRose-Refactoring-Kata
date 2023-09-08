using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const string AGEDBRIE = "Aged Brie";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const string BACKSTAGEPASS = "Backstage passes to a TAFKAL80ETC concert";
        private readonly List<string> ItemNames = new List<string> { AGEDBRIE, SULFURAS, BACKSTAGEPASS };
        private readonly IList<Item> Items;
        public GildedRose(IList<Item> items) => Items = items;
        public IList<Item> GetItems() => Items;
        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                UpdateItemQuality(item);
            }
        }
        private void UpdateItemQuality(Item item)
        {
            if (!ItemNames.Contains(item.Name))
            {
                AdjustQuality(item, -1);
            }
            else
            {
                AdjustQuality(item, 1);
                if (item.Name == BACKSTAGEPASS)
                {
                    if (item.SellIn < 11)
                    {
                        AdjustQuality(item, 1);
                    }
                    if (item.SellIn < 6)
                    {
                        AdjustQuality(item, 1);
                    }
                }
            }
            if (item.Name != SULFURAS)
            {
                item.SellIn--;
            }
            if (item.SellIn < 0)
            {
                if (item.Name != AGEDBRIE)
                {
                    if (item.Name != BACKSTAGEPASS && item.Name != SULFURAS)
                    {
                        AdjustQuality(item, -1);
                    }
                    else
                    {
                        AdjustQuality(item, 0);
                    }
                }
                else
                {
                    AdjustQuality(item, +1);
                }
            }
        }
        private static void AdjustQuality(Item item, int adjustment)
        {
            int newQuality = item.Quality + adjustment;
            bool inRange = newQuality <= 50 && newQuality >= 0;
            if (adjustment is 0)
            {
                item.Quality = 0;
            }
            if (inRange)
            {
                item.Quality += adjustment;
            }
        }
    }
}
