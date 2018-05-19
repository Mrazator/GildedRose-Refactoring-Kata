using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Strategies.Quality.Common;
using csharp.Strategies.Quality.Interfaces;

namespace csharp.Strategies.Quality
{
    public class BackstageQualityStrategy : CommonQualityStrategy, IQualityStrategy
    {
        public void UpdateQuality(Item item, bool sellByDateHasPassed = false)
        {
            if (!sellByDateHasPassed)
                IncreaseBackstageQuality(item);
            else
                item.Quality = 0;
        }

        private static void IncreaseBackstageQuality(Item item)
        {
            if (item.SellIn < 5)
                IncreaseQualityBy(item, 3);
            else if (item.SellIn < 10)
                IncreaseQualityBy(item, 2);
            else
                IncreaseQualityBy(item);
        }
    }
}
