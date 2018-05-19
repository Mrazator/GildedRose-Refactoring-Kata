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
                //podle me by se melo nejdriv lower sell in a az potom pocitat qualitu,
                //ale nechci mit jiny vysledek nez puvodni reseni
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
                    BackStageQuality(item, sellByDateHasPassed);
                    break;
                case "Conjured Mana Cake":
                    LowerQualityBy(item, 2);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    LowerQualityBy(item);
                    break;
            }
        }

        private static void BackStageQuality(Item item, bool sellByDateHasPassed)
        {
            if (!sellByDateHasPassed)
                IncreaseBackstageQuality(item);
            else
                item.Quality = 0;
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

        private static void LowerSellInByOne(Item item)
        {
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    item.SellIn = item.SellIn - 1;
                    break;
            }
        }

        private static void IncreaseQualityBy(Item item, int by = 1)
        {
            var result = item.Quality + by;
            item.Quality = result >= 50 ? 50 : result;
        }

        private static void LowerQualityBy(Item item, int by = 1)
        {
            var result = item.Quality - by;
            item.Quality = result <= 0 ? 0 : result;
        }
    }
}
