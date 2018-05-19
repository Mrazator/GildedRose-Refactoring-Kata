using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Strategies.Quality;
using csharp.Strategies.Quality.Interfaces;

namespace csharp.Factories
{
    public class QualityStrategyFactory
    {
        public static IQualityStrategy Create(string itemName)
        {
            switch (itemName)
            {
                case "Aged Brie":
                    return new AgedBrieQualityStrategy(); // IncreaseQualityBy(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstageQualityStrategy();
                case "Conjured Mana Cake":
                    return new ConjuredQualityStrategy(); // LowerQualityBy(item, 2);
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasQualityStrategy();
                default:
                    return new DefaultQualityStrategy(); // LowerQualityBy(item);
            }
        }
    }
}
