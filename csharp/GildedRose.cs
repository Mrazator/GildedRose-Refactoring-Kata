using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            this._items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (!item.Name.Contains("Sulfuras, Hand of Ragnaros"))
                {
                    ManageQualityByProductType(item);
                    LowerSellInByOne(item);
                }


                if (item.SellIn < 0)
                {
                    if (item.Name == "Aged Brie")
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                    else
                    {
                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                        else
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name == "Sulfuras, Hand of Ragnaros") continue;
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                }
            }
        }

        private static void ManageQualityByProductType(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    IncreaseQualityBy(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    IncreaseBackstageQuality(item);
                    break;
                default:
                    LowerQualityBy(item);
                    break;
            }
        }

        private static void IncreaseQualityBy(Item item, int by = 1)
        {
            if (item.Quality + by >= 50)
            {
                item.Quality = 50;
            }
            else
            {
                item.Quality = item.Quality + by;
            }
        }

        private static void IncreaseBackstageQuality(Item item)
        {
            if (item.SellIn <= 5)
            {
                IncreaseQualityBy(item, 3);
            }
            else if (item.SellIn <= 10)
            {
                IncreaseQualityBy(item, 2);
            }
            else
            {
                IncreaseQualityBy(item);
            }
        }

        private static void LowerQualityBy(Item item, int by = 1)
        {
            if (item.Quality - by <= 0)
            {
                item.Quality = 0;
            }
            else
            {
                item.Quality = item.Quality - by;
            }
        }

        private static void LowerSellInByOne(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}
