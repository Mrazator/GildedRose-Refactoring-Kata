using System.Collections.Generic;
using csharp.Factories;
using csharp.Strategies.Quality;
using csharp.Strategies.Quality.Interfaces;

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
                SellInStrategyFactory.Create(item.Name).UpdateSellIn(item);
                QualityStrategyFactory.Create(item.Name).UpdateQuality(item, item.SellIn < 0);
            }
        }
    }
}
