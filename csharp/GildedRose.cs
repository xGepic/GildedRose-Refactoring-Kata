using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const string AGEDBRIE = "Aged Brie";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const string BACKSTAGEPASS = "Backstage passes to a TAFKAL80ETC concert";
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
            if (item.Name != AGEDBRIE && item.Name != BACKSTAGEPASS)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != SULFURAS)
                    {
                        item.Quality--;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                    if (item.Name == BACKSTAGEPASS)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality++;
                            }
                        }
                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality++;
                            }
                        }
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
                    if (item.Name != BACKSTAGEPASS)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != SULFURAS)
                            {
                                item.Quality--;
                            }
                        }
                    }
                    else
                    {
                        item.Quality -= item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }
            }
        }
    }
}
