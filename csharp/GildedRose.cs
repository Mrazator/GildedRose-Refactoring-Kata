using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (item.Name.Contains("Sulfuras, Hand of Ragnaros")) continue;

                ManageQualityByProductType(item);
                LowerSellInByOne(item);

                if (item.SellIn < 0)
                    ManageQualityByProductType(item, true);
            }
        }

        private static void ManageQualityByProductType(Item item, bool sellByDateHasPassed = false)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    IncreaseQualityBy(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    if (!sellByDateHasPassed)
                        IncreaseBackstageQuality(item);
                    else
                        item.Quality = 0;
                    break;
                default:
                    LowerQualityBy(item);
                    break;
            }
        }

        private static void IncreaseBackstageQuality(Item item)
        {
            if (item.SellIn <= 5)
                IncreaseQualityBy(item, 3);
            else if (item.SellIn <= 10)
                IncreaseQualityBy(item, 2);
            else
                IncreaseQualityBy(item);
        }

        private static void IncreaseQualityBy(Item item, int by = 1)
        {
            if (item.Quality + by >= 50)
                item.Quality = 50;
            else
                item.Quality = item.Quality + by;
        }

        private static void LowerQualityBy(Item item, int by = 1)
        {
            if (item.Quality - by <= 0)
                item.Quality = 0;
            else
                item.Quality = item.Quality - by;
        }

        private static void LowerSellInByOne(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}
